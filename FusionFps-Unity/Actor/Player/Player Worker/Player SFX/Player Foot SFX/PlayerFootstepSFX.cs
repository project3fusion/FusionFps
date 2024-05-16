using AnimationState = FusionFPS.States.AnimationState;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerFootstepSFX {
        private PlayerSFX playerSFX;

        public bool isFootstepSFXEnabled;

        public PlayerFootstepSFX(PlayerSFX playerSFX) => this.playerSFX = playerSFX;

        public void PlayerFootSFXToggle(AnimationState animationState) {
            if (animationState == AnimationState.Idle) isFootstepSFXEnabled = false;
            else isFootstepSFXEnabled = true;
        }
    }
}