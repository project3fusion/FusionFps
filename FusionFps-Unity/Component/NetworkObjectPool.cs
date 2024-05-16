using System.Collections;
using System.Collections.Generic;
using FusionFPS.Components.Projectiles.Bullet;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Pool;
using FusionFPS.Actors.Players;
using FusionFPS.Managers.Server;

namespace FusionFPS.Components.Network {
    public class NetworkObjectPool {
        public GameObject prefab;
        public Player player;
        public Transform poolTransform;
        public ObjectPool<NetworkObject> objectPool;
        public List<NetworkObject> poolGameObjects;
        public int defaultCapacity;

        public NetworkObjectPool(GameObject prefab, Player player, Transform poolTransform, int defaultCapacity) {
            this.prefab = prefab;
            this.player = player;
            this.poolTransform = poolTransform;
            this.defaultCapacity = defaultCapacity;
            InitializePool();
        }

        public void InitializePool() {
            objectPool = new ObjectPool<NetworkObject>(
                CreateNetworkObject,
                ActivateNetworkObject,
                DeactivateNetworkObject,
                DestroyNetworkObject,
                defaultCapacity: defaultCapacity
            );
            poolGameObjects = new List<NetworkObject>();
            for (int i = 0; i < defaultCapacity; i++) {
                NetworkObject networkObject = objectPool.Get();
                poolGameObjects.Add(networkObject);
                networkObject.Spawn();
            }
            foreach (var networkObject in poolGameObjects) objectPool.Release(networkObject);
            NetworkManager.Singleton.PrefabHandler.AddHandler(prefab, new NetworkObjectPoolPrefabHandler(this));
        }

        private NetworkObject CreateNetworkObject() {
            GameObject networkGameObject = ServerManager.Instance.InstantiateGameObject(prefab, Vector3.zero, Quaternion.identity, poolTransform);
            networkGameObject.GetComponent<BulletProjectile>().owner = player;
            return networkGameObject.GetComponent<NetworkObject>();
        }

        public NetworkObject GetNetworkObject(Vector3 position, Quaternion rotation) {
            NetworkObject networkObject = objectPool.Get();
            networkObject.transform.position = position;
            networkObject.transform.rotation = rotation;
            if(!networkObject.IsSpawned) networkObject.Spawn();
            //networkObject.TrySetParent(poolTransform);
            return networkObject;
        }

        private void ActivateNetworkObject(NetworkObject networkObject) {
            networkObject.gameObject.SetActive(true);
        }

        private void DeactivateNetworkObject(NetworkObject networkObject) {
            networkObject.gameObject.SetActive(false);
        }

        private void DestroyNetworkObject(NetworkObject networkObject) {
            ServerManager.Instance.DestroyGameObject(networkObject.gameObject);
        }

        public void ReturnNetworkObject(NetworkObject networkObject) {
            objectPool.Release(networkObject);
        }
    }
}