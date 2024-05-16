namespace FusionFPS.Actors.Players.Workers {
    public class PlayerAttackSFX {
        private PlayerSFX playerSFX;

        public PlayerAttackSFX(PlayerSFX playerSFX) {
            this.playerSFX = playerSFX;
        }

        public void PlaySingleAttackSFX() => playerSFX.playerWorker.playerWeapon.weapon.weaponWorker.weaponSFX.weaponAttackSFX.PlaySingleAttackSFX();

        public void PlayMultiAttackSFX() => playerSFX.playerWorker.playerWeapon.weapon.weaponWorker.weaponSFX.weaponAttackSFX.PlayMultiAttackSFX();

        public void StopAttackSFX() => playerSFX.playerWorker.playerWeapon.weapon.weaponWorker.weaponSFX.weaponAttackSFX.StopAttackSFX();

        public void PlayNoAmmoSFX() => playerSFX.playerWorker.playerWeapon.weapon.weaponWorker.weaponSFX.weaponAttackSFX.PlayNoAmmoSFX();

        public void PlayAttackModeChangeSFX() => playerSFX.playerWorker.playerWeapon.weapon.weaponWorker.weaponSFX.weaponAttackSFX.PlayAttackModeChangeSFX();
    }
}