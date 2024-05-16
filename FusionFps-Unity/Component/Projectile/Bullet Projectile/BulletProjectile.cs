using UnityEngine;
using Unity.Netcode;
using FusionFPS.Actors.Players;
using System.Collections;

namespace FusionFPS.Components.Projectiles.Bullet {
    public class BulletProjectile : Projectile {
        public Player owner;

        public void OnEnable() {
            if (!IsServer) return;
            StartCoroutine(DestroyAfterTime(2.5f));
        }

        public void Update() {
            if (!IsServer) return;
            transform.position += transform.forward * Time.deltaTime * 40f;
        }

        public void OnTriggerEnter(Collider other) {
            if (!IsServer) return;
            if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
                Player player = other.GetComponent<Player>();
                if (player == owner) return;
                player.RecieveDamage(10f);
                owner.playerWorker.playerPool.playerAttackPool.projectileNetworkObjectPool.ReturnNetworkObject(GetComponent<NetworkObject>());
            }
        }

        public IEnumerator DestroyAfterTime(float time) {
            yield return new WaitForSeconds(time);
            owner.playerWorker.playerPool.playerAttackPool.projectileNetworkObjectPool.ReturnNetworkObject(GetComponent<NetworkObject>());
        }
    }
}