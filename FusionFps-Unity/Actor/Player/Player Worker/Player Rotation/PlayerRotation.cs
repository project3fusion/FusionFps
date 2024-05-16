using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerRotation {
        private PlayerWorker playerWorker;

        public Transform rotationTransform, targetTransform, modelTransform;

        private Vector3 rotationTransformPosition = new Vector3(0f, 1.6f, 0f);
        private Vector3 targetTransformPosition = new Vector3(0f, 1.6f, 2f);

        private float rotationSpeed = 75f, smoothRotationSpeed = 75f, rotationThreshold = 1f, bodyRotationSpeed = 250f;

        public Quaternion playerRotation, rotationTransformRotation;

        public PlayerRotation(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ServerStart() => SetServerRotationTransform();

        public void ClientStart() => SetClientRotationTransform();

        public void SetServerRotationTransform() => SetServerComponents();

        public void SetClientRotationTransform() => SetClientComponents();

        public void SetServerComponents() {
            modelTransform = playerWorker.player.transform.GetChild(0);
            rotationTransform = playerWorker.player.transform.Find("RotationTransform");
            targetTransform = playerWorker.player.transform.Find("RotationTransform/TargetTransform");
            rotationTransform.localPosition = rotationTransformPosition;
            targetTransform.localPosition = targetTransformPosition;
        }

        public void SetClientComponents() {
            rotationTransform = playerWorker.player.transform.Find("RotationTransform");
            targetTransform = playerWorker.player.transform.Find("RotationTransform/TargetTransform");
        }

        public void ServerUpdate() {
            playerRotation = modelTransform.rotation;
            rotationTransformRotation = rotationTransform.rotation;
            
            float yAngleDifference = Mathf.Abs(playerRotation.eulerAngles.y - rotationTransformRotation.eulerAngles.y);
            float rotationDirection = Mathf.Sign(playerRotation.eulerAngles.y - rotationTransformRotation.eulerAngles.y);

            if (playerWorker.playerMovement.isMoving) {
                RotatePlayerModel();
                playerWorker.playerAnimation.RotateAnimationRequest(0);
            }
            else if (yAngleDifference > rotationThreshold) {
                RotatePlayerModel();
                playerWorker.playerAnimation.RotateAnimationRequest(rotationDirection);
            }
            else playerWorker.playerAnimation.RotateAnimationRequest(0);
        }

        public void ClientUpdate() {
            //rotationTransform.rotation = playerWorker.player.rotation.Value;
        }

        public void RotationRequest(Vector2 rotationInput) {
            if(playerWorker.player.isPlayerFunctional) ChangeRotationTransform(rotationInput);
        }

        public void ChangeRotationTransform(Vector2 rotationInput) {
            float rotationX = rotationInput.x * rotationSpeed * Time.deltaTime;
            float rotationY = - rotationInput.y * rotationSpeed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.Euler(rotationTransform.eulerAngles.x + rotationY, rotationTransform.eulerAngles.y + rotationX, 0f);
            if(targetRotation.eulerAngles.x >= -30 && targetRotation.eulerAngles.x <= 80) rotationTransform.rotation = Quaternion.Lerp(rotationTransform.rotation, targetRotation, smoothRotationSpeed * Time.deltaTime);
            //playerWorker.player.rotation.Value = rotationTransform.rotation;
        }

        public void RotatePlayerModel() {
            float bodyRotationSpeed = 250f;
            Vector3 playerEulerAngles = playerRotation.eulerAngles;
            Vector3 rotationTransformEulerAngles = rotationTransformRotation.eulerAngles;
            Quaternion targetBodyRotation = Quaternion.RotateTowards(playerRotation, Quaternion.Euler(playerEulerAngles.x, rotationTransformEulerAngles.y, playerEulerAngles.z), bodyRotationSpeed * Time.deltaTime);
            modelTransform.rotation = targetBodyRotation;
        }
    }
}