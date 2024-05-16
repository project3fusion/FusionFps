namespace FusionFPS.Actors.Players.Workers {
    public class PlayerPool {
        public PlayerWorker playerWorker;

        public PlayerAttackPool playerAttackPool;

        public PlayerPool(PlayerWorker playerWorker) {
            this.playerWorker = playerWorker;
            
            playerAttackPool = new PlayerAttackPool(this);
        }
    }
}