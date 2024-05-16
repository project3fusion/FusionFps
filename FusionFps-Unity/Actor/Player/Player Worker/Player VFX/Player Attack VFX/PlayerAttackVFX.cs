namespace FusionFPS.Actors.Players.Workers {
    public class PlayerAttackVFX {
        private PlayerVFX playerVFX;

        public PlayerAttackVFX(PlayerVFX playerVFX) => this.playerVFX = playerVFX;

        public void PlaySingleAttackVFX() => playerVFX.playerWorker.playerWeapon.weapon.weaponWorker.weaponVFX.weaponAttackVFX.PlaySingleAttackVFX();

        public void PlayMultiAttackVFX() => playerVFX.playerWorker.playerWeapon.weapon.weaponWorker.weaponVFX.weaponAttackVFX.PlayMultiAttackVFX();

        public void StopAttackVFX() => playerVFX.playerWorker.playerWeapon.weapon.weaponWorker.weaponVFX.weaponAttackVFX.StopMultiAttackVFX();
    }
}