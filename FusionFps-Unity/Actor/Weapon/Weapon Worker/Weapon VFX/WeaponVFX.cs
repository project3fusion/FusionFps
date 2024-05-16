namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponVFX {
        public WeaponWorker weaponWorker;

        public WeaponAttackVFX weaponAttackVFX;

        public WeaponVFX(WeaponWorker weaponWorker) {
            this.weaponWorker = weaponWorker;
            weaponAttackVFX = new WeaponAttackVFX(this);
        }
    }
}