using UnityEngine;

namespace FusionFPS.Managers.Client {
    public class ClientManager : MonoBehaviour {
        public static ClientManager Instance;

        public ClientUIManager clientUIManager;

        public void Awake() {
            if (Instance != null) Destroy(this);
            Instance = this;
            clientUIManager = new ClientUIManager();
        }

        public void Start() {
            clientUIManager.Start();
        }

        public GameObject InstantiateGameObject(GameObject prefab) => Instantiate(prefab);

        public void DestroyGameObject(GameObject gameObject) => Destroy(gameObject);
    }
}