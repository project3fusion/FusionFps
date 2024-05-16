using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerMovementInput {
        private PlayerInput playerInput;

        public PlayerMovementInput(PlayerInput playerInput) => this.playerInput = playerInput;

        public void ClientOwnerUpdate() {
            // if (playerInput.movementInput != Vector2.zero) SendMovementRequest();
            SendMovementRequest();
        }
        
        public void SendMovementRequest() {
            playerInput.playerWorker.player.PlayerMovementRequestServerRpc(playerInput.movementInput, playerInput.sprintInput);
        }
    }
}