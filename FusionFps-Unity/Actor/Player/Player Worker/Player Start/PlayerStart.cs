namespace FusionFPS.Actors.Players.Workers {
    public class PlayerStart {
        private PlayerWorker playerWorker;

        public PlayerStart(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void Start() {
            if(playerWorker.player.IsServer) {
                playerWorker.playerIK.ServerStart();
                playerWorker.playerAnimation.ServerStart();
                playerWorker.playerInventory.ServerStart();
                playerWorker.playerPhysics.ServerStart();
                playerWorker.playerRotation.ServerStart();
                playerWorker.playerSpawn.ServerStart();
                playerWorker.playerStats.ServerStart();
            }
            if(playerWorker.player.IsClient) {
                playerWorker.playerIK.ClientStart();
                playerWorker.playerAnimation.ClientStart();
                playerWorker.playerCamera.ClientStart();
                playerWorker.playerInventory.ClientStart();
                playerWorker.playerRotation.ClientStart();
                if (playerWorker.player.IsOwner) {
                    playerWorker.playerCamera.ClientOwnerStart();
                    playerWorker.playerCursor.ClientOwnerStart();
                    playerWorker.playerInput.ClientOwnerStart();
                }
            }
        }
    }
}