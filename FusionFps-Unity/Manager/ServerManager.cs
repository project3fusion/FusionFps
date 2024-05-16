using Unity.Netcode;
using UnityEngine;

namespace FusionFPS.Managers.Server {
    public class ServerManager : NetworkBehaviour {
        public static ServerManager Instance;

        public void Awake() {
            if(Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public GameObject InstantiateGameObject(GameObject prefab) => Instantiate(prefab);
        
        public GameObject InstantiateGameObject(GameObject prefab, Vector3 position, Quaternion rotation) => Instantiate(prefab, position, rotation);

        public GameObject InstantiateGameObject(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent) => Instantiate(prefab, position, rotation, parent);

        public void DestroyGameObject(GameObject gameObject) => Destroy(gameObject);
    }
}