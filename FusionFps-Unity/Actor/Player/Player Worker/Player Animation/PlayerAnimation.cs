using UnityEngine;
using AnimationState = FusionFPS.States.AnimationState;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerAnimation {
        private PlayerWorker playerWorker;

        private bool left, right, up, down;

        public Animator animator;

        public PlayerAnimation(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ServerStart() => animator = playerWorker.player.transform.GetChild(0).GetComponent<Animator>();

        public void ClientStart() => animator = playerWorker.player.transform.GetChild(0).GetComponent<Animator>();

        public void AttackAnimationRequest(bool isMultiAttack, bool value) {
            if (isMultiAttack) animator.SetBool(AnimationState.MultiAttack.ToString(), value);
            else animator.SetTrigger(AnimationState.SingleAttack.ToString());
        }

        public void ReloadAnimationRequest() => animator.SetTrigger(AnimationState.Reload.ToString());

        public void MovementAnimationRequest(AnimationState animationState) => animator.SetFloat("MoveSpeed", ((float) animationState) / 4);
        
        public void MovementAnimationRequest(AnimationState animationState, Vector2 movementInput) {
            animator.SetFloat("MoveSpeed", ((float) animationState) / 4);
            animator.SetFloat("XMovement", movementInput.y < 0 ? -movementInput.x : movementInput.x);
            animator.SetFloat("YMovement", movementInput.y);
        }

        public void RotateAnimationRequest(float rotationDirection) {
            animator.SetBool(AnimationState.RotateLeft.ToString(), rotationDirection < 0);
            animator.SetBool(AnimationState.RotateRight.ToString(), rotationDirection > 0);
        }
    }
}