namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponStats {
        private WeaponWorker weaponWorker;

        public uint ammo, maxAvailableAmmo, maxAmmo, backupAmmo;
        public float reloadTime;

        public WeaponStats(WeaponWorker weaponWorker) {
            this.weaponWorker = weaponWorker;
            ammo = weaponWorker.weapon.weaponSettings.ammo;
            maxAvailableAmmo = weaponWorker.weapon.weaponSettings.maxAvailableAmmo;
            maxAmmo = weaponWorker.weapon.weaponSettings.maxAmmo;
            backupAmmo = weaponWorker.weapon.weaponSettings.backupAmmo;
            reloadTime = weaponWorker.weapon.weaponSettings.reloadTime;
        }

        public bool CheckAmmo() {
            if (ammo == 0) return false;
            ammo--;
            weaponWorker.weapon.owner.ammo.Value = ammo;
            return true;
        }

        public bool CheckMaxAvailableAmmo() => ammo == maxAvailableAmmo;

        public void ReloadAmmo() {
            uint requiredAmount = maxAvailableAmmo - ammo;
            if (backupAmmo < requiredAmount) requiredAmount = backupAmmo;
            ammo += requiredAmount;
            backupAmmo -= requiredAmount;
            weaponWorker.weapon.owner.ammo.Value = ammo;
            weaponWorker.weapon.owner.backupAmmo.Value = backupAmmo;
        }
    }
}