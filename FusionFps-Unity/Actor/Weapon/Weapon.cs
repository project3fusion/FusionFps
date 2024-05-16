using FusionFPS.Actors.Players;
using FusionFPS.Actors.Weapons.Workers;
using UnityEngine;

namespace FusionFPS.Actors.Weapons {
    public class Weapon : MonoBehaviour {
        public WeaponWorker weaponWorker;

        public Player owner;

        public WeaponSettings weaponSettings;

        public void SetOwner(Player owner) {
            this.owner = owner;
            weaponWorker.Awake();
        }

        public void Awake() => weaponWorker = new WeaponWorker(this);

        public void Start() => weaponWorker.Start();

        public void Update() => weaponWorker.Update();
    }
}