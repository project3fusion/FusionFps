namespace FusionFPS.Actors.Players.Workers {
    public class PlayerVFX {
        public PlayerWorker playerWorker;

        public PlayerAttackVFX playerAttackVFX;

        public PlayerVFX(PlayerWorker playerWorker) {
            this.playerWorker = playerWorker;
            playerAttackVFX = new PlayerAttackVFX(this);
        }
    }
}