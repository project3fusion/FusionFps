namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponSFX {
        public WeaponWorker weaponWorker;

        public WeaponAttackSFX weaponAttackSFX;

        public WeaponSFX(WeaponWorker weaponWorker) {
            this.weaponWorker = weaponWorker;
            weaponAttackSFX = new WeaponAttackSFX(this);
        }
    }
}