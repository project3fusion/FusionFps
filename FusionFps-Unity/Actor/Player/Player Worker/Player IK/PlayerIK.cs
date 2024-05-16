using UnityEngine;
using UnityEngine.Animations.Rigging;
using System.Collections;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerIK {
        private PlayerWorker playerWorker;

        public GameObject modelGameObject, rigGameObject, bodyAimGameObject, aimGameObject, secondHandGrabGameObject;

        public Transform targetTransform, modelTransform;
        public Transform spineTransform, leftHandTransform, rightHandTransform;

        private Vector3 secondHandGrabTargetPosition = new Vector3(0.3f, -0.11f, 0.01f);
        private Quaternion secondHandGrabTargetRotation = Quaternion.Euler(-40.5f, 227.8f, -57.6f);
        private Vector3 secondHandGrabHintPosition = new Vector3(0.507f, -0.337f, -0.562f);
        private Vector3 magazineLeftHandPosition = new Vector3(-0.157f, 0.032f, -0.048f);
        private Quaternion magazineLeftHandRotation = Quaternion.Euler(-201.5f, 35.562f, -118.518f);
        private Vector3 magazineOriginalPosition;
        private Quaternion magazineOriginalRotation;

        private MultiAimConstraint aimConstraint;
        private TwoBoneIKConstraint secondHandGrabContraint;
        private Rig rig;

        private Animator animator;

        private RigBuilder rigBuilder;

        public bool isIKEnabled = true, isStarted = false, isIKSet = false;

        public PlayerIK(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ServerStart() => playerWorker.player.StartCoroutine(SetPlayerIKCoroutine());
        
        public void ClientStart() => playerWorker.player.StartCoroutine(SetPlayerIKCoroutine());

        public IEnumerator SetPlayerIKCoroutine() {
            while(true) {
                if (playerWorker.playerRotation.targetTransform != null && playerWorker.playerAnimation.animator != null) {
                        SetPlayerIK();
                        break;
                    }
                yield return null;
            }
        }

        public void SetPlayerIK() {
            modelGameObject = playerWorker.player.transform.GetChild(0).gameObject;
            modelTransform = modelGameObject.transform;
            animator = modelGameObject.GetComponent<Animator>();
            animator.enabled = false;
            SetPlayerIKRig();
            SetPlayerIKRigAimConstraints();
            rigBuilder.Build();
            animator.enabled = true;
            isIKSet = true;
            playerWorker.player.StartCoroutine(playerWorker.playerCamera.SetPlayerCameraCoroutine());
        }

        public void SetPlayerIKRig() {
            targetTransform = playerWorker.player.transform.Find("RotationTransform/TargetTransform");
            modelGameObject.AddComponent<RigBuilder>();
            rigBuilder = modelGameObject.GetComponent<RigBuilder>();
            rigGameObject = (new GameObject("Rig 1")).transform.gameObject;
            rigGameObject.AddComponent<Rig>();
            rigGameObject.transform.SetParent(modelGameObject.transform);
            rig = rigGameObject.GetComponent<Rig>();
            rigBuilder.layers.Add(new RigLayer(rig, true));
        }

        public void SetPlayerIKRigAimConstraints() {
            bodyAimGameObject = (new GameObject("BodyAim")).transform.gameObject;
            aimGameObject = (new GameObject("Aim")).transform.gameObject;
            secondHandGrabGameObject = (new GameObject("SecondHandGrab")).transform.gameObject;
            
            bodyAimGameObject.AddComponent<MultiAimConstraint>();
            aimGameObject.AddComponent<MultiAimConstraint>();
            secondHandGrabGameObject.AddComponent<TwoBoneIKConstraint>();

            MultiAimConstraint bodyAimContraint = bodyAimGameObject.GetComponent<MultiAimConstraint>();
            aimConstraint = aimGameObject.GetComponent<MultiAimConstraint>();
            secondHandGrabContraint = secondHandGrabGameObject.GetComponent<TwoBoneIKConstraint>();
            bodyAimContraint.Reset();
            aimConstraint.Reset();
            secondHandGrabContraint.Reset();

            spineTransform = modelGameObject.transform.Find("SK_Mannequin/root/pelvis/spine_01");
            bodyAimContraint.data.constrainedObject = spineTransform;
            WeightedTransformArray spineSourceObjects = new WeightedTransformArray();
            spineSourceObjects.Add(new WeightedTransform(targetTransform, 0.7f));
            bodyAimContraint.data.sourceObjects = spineSourceObjects;
            bodyAimContraint.data.aimAxis = MultiAimConstraintData.Axis.Y_NEG;
            bodyAimContraint.data.upAxis = MultiAimConstraintData.Axis.Z_NEG;

            rightHandTransform = modelGameObject.transform.Find("SK_Mannequin/root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r");
            aimConstraint.data.constrainedObject = rightHandTransform;
            WeightedTransformArray handSourceObjects = new WeightedTransformArray();
            handSourceObjects.Add(new WeightedTransform(targetTransform, 1f));
            aimConstraint.data.sourceObjects = handSourceObjects;
            aimConstraint.data.aimAxis = MultiAimConstraintData.Axis.X;
            aimConstraint.data.upAxis = MultiAimConstraintData.Axis.Z;

            leftHandTransform = modelGameObject.transform.Find("SK_Mannequin/root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l/lowerarm_l/hand_l");
            Transform leftLowerArmTransform = modelGameObject.transform.Find("SK_Mannequin/root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l/lowerarm_l");
            Transform leftUpperArmTransform = modelGameObject.transform.Find("SK_Mannequin/root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l");
            secondHandGrabContraint.data.root = leftUpperArmTransform;
            secondHandGrabContraint.data.mid = leftLowerArmTransform;
            secondHandGrabContraint.data.tip = leftHandTransform;

            Transform secondHandGrabTargetTransform = (new GameObject("SecondHandGrab_target")).transform;
            Transform secondHandGrabHintTransform = (new GameObject("SecondHandGrab_hint")).transform;
            secondHandGrabTargetTransform.SetParent(rightHandTransform);
            secondHandGrabHintTransform.SetParent(rightHandTransform);
            secondHandGrabTargetTransform.localPosition = secondHandGrabTargetPosition;
            secondHandGrabTargetTransform.localRotation = secondHandGrabTargetRotation;
            secondHandGrabHintTransform.localPosition = secondHandGrabHintPosition;
            secondHandGrabContraint.data.target = secondHandGrabTargetTransform;
            secondHandGrabContraint.data.hint = secondHandGrabHintTransform;

            bodyAimGameObject.transform.SetParent(rigGameObject.transform);
            aimGameObject.transform.SetParent(rigGameObject.transform);
            secondHandGrabGameObject.transform.SetParent(rigGameObject.transform);
        }

        public void ClientUpdate() {
            if(isIKSet) CheckPlayerIK();
        }

        public void CheckPlayerIK() {
            int reloadLayerIndex = playerWorker.playerAnimation.animator.GetLayerIndex("Reload Layer");
            float moveSpeed = playerWorker.playerAnimation.animator.GetFloat("MoveSpeed");
            AnimatorStateInfo reloadLayerStateInfo = playerWorker.playerAnimation.animator.GetCurrentAnimatorStateInfo(reloadLayerIndex);
            if (reloadLayerStateInfo.IsName("Reload")) {
                isIKEnabled = false;
                if (!isStarted) {
                    isStarted = true;
                    playerWorker.player.StartCoroutine(ReduceRig());
                }
            }
            else if (moveSpeed == 0.75f) {
                isIKEnabled = false;
                if (!isStarted) {
                    isStarted = true;
                    playerWorker.player.StartCoroutine(ReduceRig());
                }
            }
            else if (!isIKEnabled){
                isIKEnabled = true;
                if (isStarted) {
                    isStarted = false;
                    playerWorker.player.StartCoroutine(IncreaseRig());
                }
            }
        }

        public IEnumerator ReduceRig() {
            while (rig.weight > 0.05f) {
                rig.weight -= 5f * Time.deltaTime;
                if (isIKEnabled) break;
                yield return null;
            }
            rig.weight = 0f;
            RemoveMagazineFromLeftHand();
        }

        public IEnumerator IncreaseRig() {
            while (rig.weight < 1f) {
                rig.weight += 5f * Time.deltaTime;
                if (!isIKEnabled) break;
                yield return null;
            }
            rig.weight = 1f;
            AddMagazineToLeftHand();
        }

        public void AddMagazineToLeftHand() {
            magazineOriginalPosition = playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.magazineTransform.localPosition;
            magazineOriginalRotation = playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.magazineTransform.localRotation;
            playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.magazineTransform.SetParent(leftHandTransform);
            playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.magazineTransform.localPosition = magazineLeftHandPosition;
            playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.magazineTransform.localRotation = magazineLeftHandRotation;
        }

        public void RemoveMagazineFromLeftHand() {
            playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.magazineTransform.SetParent(playerWorker.playerWeapon.weapon.transform);
            playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.magazineTransform.localPosition = magazineOriginalPosition;
            playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.magazineTransform.localRotation = magazineOriginalRotation;
        }
    }
}