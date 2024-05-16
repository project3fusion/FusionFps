namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponStart {
        private WeaponWorker weaponWorker;

        public WeaponStart(WeaponWorker weaponWorker) => this.weaponWorker = weaponWorker;

        public void Start() {
            if (weaponWorker.weapon.owner.IsServer) {
                
            }
            if (weaponWorker.weapon.owner.IsClient) {
                if (weaponWorker.weapon.owner.IsOwner) {
                    // client owner code
                }
            }
        }
    }
}