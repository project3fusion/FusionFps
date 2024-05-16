using UnityEngine;

namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponComponents {
        private WeaponWorker weaponWorker;

        public Transform projectileStartPointTransform, cameraPositionTransform, scopePositionTransform, magazineTransform;
        public GameObject projectilePrefab;
        public int defaultCapacity;

        public WeaponComponents(WeaponWorker weaponWorker) => this.weaponWorker = weaponWorker;

        public void ServerAwake() => SetWeaponComponents();

        public void ClientAwake() => SetWeaponComponents();

        public void SetWeaponComponents() {
            projectileStartPointTransform = weaponWorker.weapon.transform.Find("ProjectileStartPoint");
            cameraPositionTransform = weaponWorker.weapon.transform.Find("CameraPosition");
            scopePositionTransform = weaponWorker.weapon.transform.Find("ScopePosition");
            magazineTransform = weaponWorker.weapon.transform.Find("Magazine");
            projectilePrefab = weaponWorker.weapon.weaponSettings.projectilePrefab;
            defaultCapacity = weaponWorker.weapon.weaponSettings.defaultCapacity;
        }
    }
}