using UnityEngine;

using AnimationState = FusionFPS.States.AnimationState;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerMovement {
        private PlayerWorker playerWorker;

        private Vector3 movementDirection;

        public float speed;

        public bool isMoving;

        public PlayerMovement(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void MovementRequest(Vector2 movementInput, bool sprintInput) {
            if (playerWorker.player.isPlayerFunctional) MovePlayer(movementInput, sprintInput);
        }

        public void MovePlayer(Vector2 movementInput, bool sprintInput) {
            CalculateMovementDirection(movementInput);
            CalculateSpeed(sprintInput);
            ApplyAnimation(movementInput, sprintInput);
            UpdatePlayerPosition();
        }

        public void ApplyAnimation(Vector2 movementInput, bool sprintInput) {
            if(movementInput.magnitude > 0) {
                if (sprintInput) playerWorker.playerAnimation.MovementAnimationRequest(AnimationState.Sprint, movementInput);
                else playerWorker.playerAnimation.MovementAnimationRequest(AnimationState.Run, movementInput);
                isMoving = true;
            }
            else {
                playerWorker.playerAnimation.MovementAnimationRequest(AnimationState.Idle);
                isMoving = false;
            }
        }

        public void CalculateMovementDirection(Vector2 movementInput) {
            movementDirection = playerWorker.playerIK.modelTransform.forward * movementInput.y + playerWorker.playerIK.modelTransform.right * movementInput.x;
            if (movementDirection.magnitude > 1) movementDirection.Normalize();
        }

        public void CalculateSpeed(bool sprintInput) => speed = sprintInput ? 8f : 5f;

        public void UpdatePlayerPosition() => playerWorker.player.transform.position += movementDirection * speed * Time.deltaTime;

        public void ServerUpdate() {
            // Handle player movement
        }
    }
}