namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponUpdate {
        private WeaponWorker weaponWorker;

        public WeaponUpdate(WeaponWorker weaponWorker) => this.weaponWorker = weaponWorker;

        public void Update() {
            if (weaponWorker.weapon.owner.IsServer) {
                // server code
            }
            if (weaponWorker.weapon.owner.IsClient) {
                if (weaponWorker.weapon.owner.IsOwner) {
                    // client owner code
                }
            }
        }
    }
}