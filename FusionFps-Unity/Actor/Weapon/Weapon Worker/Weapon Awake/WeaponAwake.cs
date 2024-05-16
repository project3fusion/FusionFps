namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponAwake {
        private WeaponWorker weaponWorker;

        public WeaponAwake(WeaponWorker weaponWorker) => this.weaponWorker = weaponWorker;

        public void Awake() {
            if (weaponWorker.weapon.owner.IsServer) {
                weaponWorker.weaponComponents.ServerAwake();
            }
            if (weaponWorker.weapon.owner.IsClient) {
                weaponWorker.weaponComponents.ClientAwake();
                if (weaponWorker.weapon.owner.IsOwner) {
                    // client owner code
                }
            }
        }
    }
}