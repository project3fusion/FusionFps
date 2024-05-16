namespace FusionFPS.Actors.Players.Workers {
    public class PlayerEvent {
        private PlayerWorker playerWorker;

        public PlayerEvent(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void OnPlayerDeath() {
            playerWorker.playerSpawn.Respawn();
        }

        public void OnPlayerDamage(float damage) {
            playerWorker.playerStats.ReduceHealth(damage);
        }
    }
}