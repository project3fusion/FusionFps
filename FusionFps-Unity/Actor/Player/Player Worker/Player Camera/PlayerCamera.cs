using UnityEngine;
using System.Collections;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerCamera {
        private PlayerWorker playerWorker;

        public Camera camera;

        private Vector3 currentVelocity;

        private Transform weaponCameraTransform, targetTransform, crosshairTransform;

        private bool isScopeEnabled = false, isCrosshairEnabled = true;

        public PlayerCamera(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ClientStart() => SetCameraRenderLayers();

        public void SetCameraRenderLayers() {
            if (playerWorker.player.IsOwner) return;
            foreach (Transform child in playerWorker.player.transform.GetChild(0)) {
                if (child.gameObject.layer == LayerMask.NameToLayer("PlayerLocal")) {
                    child.gameObject.layer = LayerMask.NameToLayer("Default");
                }
            }
        }

        public void ClientOwnerStart() {
            camera = Camera.main;
            camera.transform.SetParent(playerWorker.player.transform);
            crosshairTransform = GameObject.Find("Crosshair").transform;
            SetPlayerCameraLayers();
            CloseCursor();
        }

        public void SetPlayerCameraLayers() {
            camera.cullingMask = ~LayerMask.GetMask("PlayerLocal");
        }

        public void CloseCursor() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void SetPlayerCamera() {
            weaponCameraTransform = playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.cameraPositionTransform;
            targetTransform = playerWorker.playerIK.targetTransform;
        }

        public IEnumerator SetPlayerCameraCoroutine() {
            while(true) {
                if (playerWorker.playerWeapon.weapon != null && playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.cameraPositionTransform != null) {
                    SetPlayerCamera();
                    break;
                }
                yield return null;
            }
        }

        public void ToggleScopeRequest() {
            if (playerWorker.player.isPlayerFunctional) ToggleScope();
        }

        public void ToggleScope() {
            isScopeEnabled = !isScopeEnabled;
            if (isScopeEnabled) weaponCameraTransform = playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.scopePositionTransform;
            else weaponCameraTransform = playerWorker.playerWeapon.weapon.weaponWorker.weaponComponents.cameraPositionTransform;
            ToggleCrosshair();
        }

        public void ToggleCrosshair() {
            isCrosshairEnabled = !isCrosshairEnabled;
            crosshairTransform.gameObject.SetActive(isCrosshairEnabled);
        }

        public void ClientOwnerUpdate() {
            if (!playerWorker.playerIK.isIKSet || targetTransform == null) return;

            Quaternion targetRotation = Quaternion.LookRotation(targetTransform.position - camera.transform.position);
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, targetRotation, 10f * Time.deltaTime);

            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, weaponCameraTransform.position, ref currentVelocity, Time.deltaTime);
        }
    }
}