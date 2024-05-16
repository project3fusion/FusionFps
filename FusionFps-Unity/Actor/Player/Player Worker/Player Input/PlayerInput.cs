using UnityEngine;


namespace FusionFPS.Actors.Players.Workers {
    public class PlayerInput {
        public PlayerWorker playerWorker;

        public Vector2 movementInput, cameraInput;
        public bool crouch, leftClick, rightClick, jump, reload, sprintInput;
        public bool changeAttackMode;

        public PlayerInputs playerInputs;

        public PlayerAttackInput playerAttackInput;
        public PlayerMovementInput playerMovementInput;
        public PlayerRotationInput playerRotationInput;
        public PlayerWeaponInput playerWeaponInput;

        public PlayerInput(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ClientOwnerStart() {
            playerInputs = new PlayerInputs();
            playerAttackInput = new PlayerAttackInput(this);
            playerMovementInput = new PlayerMovementInput(this);
            playerRotationInput = new PlayerRotationInput(this);
            playerWeaponInput = new PlayerWeaponInput(this);
            playerInputs.Player.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
            playerInputs.Player.Camera.performed += ctx => cameraInput = ctx.ReadValue<Vector2>();
            playerInputs.Player.Jump.performed += ctx => jump = true;
            playerInputs.Player.Sprint.performed += ctx => sprintInput = true;
            playerInputs.Player.Sprint.canceled += ctx => sprintInput = false;
            playerInputs.Player.Crouch.performed += ctx => crouch = true;
            playerInputs.Player.Reload.performed += ctx => reload = true;
            playerInputs.Player.ChangeAttackMode.performed += ctx => changeAttackMode = true;
            playerInputs.Player.LeftClick.performed += ctx => leftClick = true;
            playerInputs.Player.LeftClick.canceled += ctx => leftClick = false;
            playerInputs.Player.RightClick.performed += ctx => rightClick = true;
            playerInputs.Enable();
        }

        public void ClientOwnerUpdate() {
            playerAttackInput.ClientOwnerUpdate();
            playerMovementInput.ClientOwnerUpdate();
            playerRotationInput.ClientOwnerUpdate();
            playerWeaponInput.ClientOwnerUpdate();
        }

        public void ClientOwnerLateUpdate() => changeAttackMode = rightClick = jump = reload = crouch = false;
    }
}