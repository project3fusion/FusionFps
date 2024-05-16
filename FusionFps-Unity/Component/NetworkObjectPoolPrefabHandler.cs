using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace FusionFPS.Components.Network {
    public class NetworkObjectPoolPrefabHandler : INetworkPrefabInstanceHandler {
        private NetworkObjectPool networkObjectPool;

        public NetworkObjectPoolPrefabHandler(NetworkObjectPool networkObjectPool) =>
            this.networkObjectPool = networkObjectPool;

        NetworkObject INetworkPrefabInstanceHandler.Instantiate(ulong ownerClientId, Vector3 position, Quaternion rotation) =>
            networkObjectPool.GetNetworkObject(position, rotation);

        void INetworkPrefabInstanceHandler.Destroy(NetworkObject networkObject) =>
            networkObjectPool.ReturnNetworkObject(networkObject);
    }
}