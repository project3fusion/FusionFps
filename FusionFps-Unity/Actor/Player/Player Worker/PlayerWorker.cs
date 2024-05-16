namespace FusionFPS.Actors.Players.Workers {
    public class PlayerWorker {
        public Player player;

        public PlayerStart playerStart;
        public PlayerUpdate playerUpdate;
        public PlayerLateUpdate playerLateUpdate;

        public PlayerAnimation playerAnimation;
        public PlayerAttack playerAttack;
        public PlayerCamera playerCamera;
        public PlayerCursor playerCursor;
        public PlayerEvent playerEvent;
        public PlayerIK playerIK;
        public PlayerInput playerInput;
        public PlayerInventory playerInventory;
        public PlayerMovement playerMovement;
        public PlayerPhysics playerPhysics;
        public PlayerPool playerPool;
        public PlayerRotation playerRotation;
        public PlayerSpawn playerSpawn;
        public PlayerStats playerStats;
        public PlayerUI playerUI;
        public PlayerSFX playerSFX;
        public PlayerVFX playerVFX;
        public PlayerWeapon playerWeapon;

        public PlayerWorker(Player player) {
            this.player = player;

            playerStart = new PlayerStart(this);
            playerUpdate = new PlayerUpdate(this);
            playerLateUpdate = new PlayerLateUpdate(this);

            playerIK = new PlayerIK(this);

            playerAnimation = new PlayerAnimation(this);
            playerAttack = new PlayerAttack(this);
            playerCamera = new PlayerCamera(this);
            playerCursor = new PlayerCursor(this);
            playerEvent = new PlayerEvent(this);
            playerInput = new PlayerInput(this);
            playerInventory = new PlayerInventory(this);
            playerMovement = new PlayerMovement(this);
            playerPhysics = new PlayerPhysics(this);
            playerPool = new PlayerPool(this);
            playerRotation = new PlayerRotation(this);
            playerSFX = new PlayerSFX(this);
            playerSpawn = new PlayerSpawn(this);
            playerStats = new PlayerStats(this);
            playerUI = new PlayerUI(this);
            playerVFX = new PlayerVFX(this);
            playerWeapon = new PlayerWeapon(this);
        }

        public void Start() => playerStart.Start();

        public void Update() => playerUpdate.Update();

        public void LateUpdate() => playerLateUpdate.LateUpdate();
    }
}