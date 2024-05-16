using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerCursor {
        private PlayerWorker playerWorker;

        public PlayerCursor(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ClientOwnerStart() {
            DisableCursor();
        }

        public void DisableCursor() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}