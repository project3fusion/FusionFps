using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerSpawn {
        public PlayerWorker playerWorker;

        public Vector3 spawnPosition = new Vector3(-5f, 3.4f, 0f);

        public PlayerSpawn(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ServerStart() => Spawn();

        public void Spawn() {
            playerWorker.player.transform.position = spawnPosition;
            playerWorker.playerInventory.AddDumbWeapon();
        }

        public void Respawn() {
            playerWorker.playerInventory.RemoveDumbWeapon();
            playerWorker.playerInventory.AddDumbWeapon();
        }
    }
}