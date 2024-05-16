namespace FusionFPS.Actors.Players.Workers {
    public class PlayerWeaponInput {
        private PlayerInput playerInput;

        public PlayerWeaponInput(PlayerInput playerInput) => this.playerInput = playerInput;

        public void ClientOwnerUpdate() {
            if (playerInput.reload) SendReloadRequest();
            if (playerInput.rightClick) SendScopeRequest();
        }

        public void SendReloadRequest() =>
            playerInput.playerWorker.player.PlayerReloadRequestServerRpc();

        public void SendScopeRequest() =>
            playerInput.playerWorker.playerCamera.ToggleScopeRequest();
    }
}