namespace FusionFPS.Actors.Players.Workers {
    public class PlayerSFX {
        public PlayerWorker playerWorker;

        public PlayerAttackSFX playerAttackSFX;

        public PlayerSFX(PlayerWorker playerWorker) {
            this.playerWorker = playerWorker;
            playerAttackSFX = new PlayerAttackSFX(this);
        }
        
    }
}