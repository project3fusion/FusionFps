using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerRotationInput {
        private PlayerInput playerInput;

        public PlayerRotationInput(PlayerInput playerInput) => this.playerInput = playerInput;

        public void ClientOwnerUpdate() {
            if (playerInput.cameraInput != Vector2.zero) SendRotationRequest();
        }

        public void SendRotationRequest() {
            playerInput.playerWorker.player.PlayerRotationRequestServerRpc(playerInput.cameraInput);
        }
    }
}