using FusionFPS.Managers.Server;
using FusionFPS.Actors.Weapons;
using FusionFPS.Managers.Client;
using System.Collections;
using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerInventory {
        private PlayerWorker playerWorker;

        private GameObject dumbWeapon;

        public PlayerInventory(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ServerStart() => playerWorker.player.StartCoroutine(AddWeaponAfterTime());

        public void ClientStart() => playerWorker.player.StartCoroutine(AddWeaponAfterTime());

        public IEnumerator AddWeaponAfterTime() {
            while(true) {
                if (playerWorker.playerIK.rightHandTransform != null) {
                    AddDumbWeapon();
                    break;
                }
                yield return null;
            }
        }
        
        public void AddDumbWeapon() {
            if (playerWorker.player.IsServer) dumbWeapon = ServerManager.Instance.InstantiateGameObject(playerWorker.player.playerSettings.dumbRifle);
            else dumbWeapon = ClientManager.Instance.InstantiateGameObject(playerWorker.player.playerSettings.dumbRifle);
            dumbWeapon.transform.SetParent(playerWorker.playerIK.rightHandTransform);
            Weapon dumbWeaponComponent = dumbWeapon.GetComponent<Weapon>();
            dumbWeapon.transform.localPosition = dumbWeaponComponent.weaponSettings.handPosition;
            dumbWeapon.transform.localRotation = Quaternion.Euler(dumbWeaponComponent.weaponSettings.handRotation);
            dumbWeaponComponent.SetOwner(playerWorker.player);
            playerWorker.playerWeapon.SetWeapon(dumbWeaponComponent);
        }

        public void RemoveDumbWeapon() {
            ServerManager.Instance.DestroyGameObject(dumbWeapon);
        }
    }
}