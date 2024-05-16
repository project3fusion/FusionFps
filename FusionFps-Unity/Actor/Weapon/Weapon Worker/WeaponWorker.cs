namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponWorker {
        public Weapon weapon;

        public WeaponAwake weaponAwake;
        public WeaponStart weaponStart;
        public WeaponUpdate weaponUpdate;

        public WeaponComponents weaponComponents;
        public WeaponSFX weaponSFX;
        public WeaponStats weaponStats;
        public WeaponVFX weaponVFX;

        public WeaponWorker(Weapon weapon) {
            this.weapon = weapon;

            weaponAwake = new WeaponAwake(this);
            weaponStart = new WeaponStart(this);
            weaponUpdate = new WeaponUpdate(this);
            
            weaponComponents = new WeaponComponents(this);
            weaponSFX = new WeaponSFX(this);
            weaponStats = new WeaponStats(this);
            weaponVFX = new WeaponVFX(this);
        }

        public void Awake() => weaponAwake.Awake();

        public void Start() => weaponStart.Start();

        public void Update() => weaponUpdate.Update();
    }
}