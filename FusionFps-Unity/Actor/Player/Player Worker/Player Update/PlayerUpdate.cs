namespace FusionFPS.Actors.Players.Workers {
    public class PlayerUpdate {
        private PlayerWorker playerWorker;

        public PlayerUpdate(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void Update() {
            if(playerWorker.player.IsServer) {
                playerWorker.playerAttack.ServerUpdate();
                playerWorker.playerMovement.ServerUpdate();
                playerWorker.playerRotation.ServerUpdate();
            }
            if(playerWorker.player.IsClient) {
                playerWorker.playerIK.ClientUpdate();
                playerWorker.playerRotation.ClientUpdate();
                if (playerWorker.player.IsOwner) {
                    playerWorker.playerCamera.ClientOwnerUpdate();
                    playerWorker.playerInput.ClientOwnerUpdate();
                    playerWorker.playerUI.ClientOwnerUpdate();
                }
            }
        }
    }
}