namespace FusionFPS.Actors.Players.Workers {
    public class PlayerStats {
        private PlayerWorker playerWorker;

        private float health = 100;

        public PlayerStats(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ServerStart() => ResetStats();

        public void ResetStats() {
            health = 100;
        }

        public void ReduceHealth(float damage) {
            if((health -= damage) <= 0) playerWorker.playerEvent.OnPlayerDeath();
        }
    }
}