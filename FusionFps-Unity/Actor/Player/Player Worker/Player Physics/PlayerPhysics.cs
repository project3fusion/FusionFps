using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerPhysics {
        private PlayerWorker playerWorker;

        public Rigidbody rigidbody;

        public PlayerPhysics(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ServerStart() {
            rigidbody = playerWorker.player.transform.GetChild(0).GetComponent<Rigidbody>();
        }
    }
}