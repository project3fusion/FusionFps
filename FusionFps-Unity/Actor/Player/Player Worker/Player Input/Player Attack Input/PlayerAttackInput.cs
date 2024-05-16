namespace FusionFPS.Actors.Players.Workers {
    public class PlayerAttackInput {
        private PlayerInput playerInput;

        public PlayerAttackInput(PlayerInput playerInput) => this.playerInput = playerInput;

        public void ClientOwnerUpdate() {
            if (playerInput.leftClick) SendAttackRequest();
            if (playerInput.changeAttackMode) SendAttackModeChangeRequest();
        }
        
        public void SendAttackRequest() =>
            playerInput.playerWorker.player.PlayerAttackRequestServerRpc();

        public void SendAttackModeChangeRequest() =>
            playerInput.playerWorker.player.PlayerAttackModeChangeRequestServerRpc();
    }
}