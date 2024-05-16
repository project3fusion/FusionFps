using FusionFPS.Actors.Weapons;
using System.Collections;
using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerWeapon {
        private PlayerWorker playerWorker;

        public Weapon weapon;

        public bool isReloading;

        public bool isWeaponReadyToAttack => !isReloading;

        public PlayerWeapon(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void SetWeapon(Weapon weapon) {
            this.weapon = weapon;
            if (!playerWorker.player.IsServer) return;
            playerWorker.playerPool.playerAttackPool.GenerateProjectilePool(
                weapon.weaponWorker.weaponComponents.projectilePrefab,
                weapon.weaponWorker.weaponComponents.projectileStartPointTransform,
                weapon.weaponWorker.weaponComponents.defaultCapacity
            );
        }

        public void ReloadAmmo() {
            if (isReloading || 
            weapon.weaponWorker.weaponStats.CheckMaxAvailableAmmo() ||
            !playerWorker.player.isPlayerFunctional) return;
            playerWorker.playerAnimation.ReloadAnimationRequest();
            playerWorker.playerWeapon.weapon.weaponWorker.weaponSFX.weaponAttackSFX.PlayReloadSFX();
            playerWorker.player.StartCoroutine(ReloadAmmoCooldown());
        }

        public IEnumerator ReloadAmmoCooldown() {
            isReloading = true;
            yield return new WaitForSeconds(weapon.weaponWorker.weaponStats.reloadTime);
            weapon.weaponWorker.weaponStats.ReloadAmmo();
            isReloading = false;
        }
    }
}