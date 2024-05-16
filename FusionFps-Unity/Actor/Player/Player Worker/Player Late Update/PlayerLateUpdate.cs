namespace FusionFPS.Actors.Players.Workers {
    public class PlayerLateUpdate {
        private PlayerWorker playerWorker;

        public PlayerLateUpdate(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void LateUpdate() {
            if(playerWorker.player.IsServer) {
                // Handle player late update
            }
            if(playerWorker.player.IsClient) {
                if (playerWorker.player.IsOwner) {
                    playerWorker.playerInput.ClientOwnerLateUpdate();
                }
            }
        }
    }
}