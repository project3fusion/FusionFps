using FusionFPS.Components.Network;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerAttackPool {
        private PlayerPool playerPool;

        public Transform projectileStartPointTransform;

        public NetworkObjectPool projectileNetworkObjectPool;

        public PlayerAttackPool(PlayerPool playerPool) {
            this.playerPool = playerPool;
        }

        public void GenerateProjectilePool(GameObject projectilePrefab, Transform projectileStartPointTransform, int projectilePoolDefaultCapacity) {
            this.projectileStartPointTransform = projectileStartPointTransform;
            projectileNetworkObjectPool = new NetworkObjectPool(projectilePrefab, playerPool.playerWorker.player, projectileStartPointTransform, projectilePoolDefaultCapacity);
        }
        
        public NetworkObject GetProjectile() =>
            projectileNetworkObjectPool.GetNetworkObject(
                projectileStartPointTransform.position,
                projectileStartPointTransform.rotation
            );
    }
}