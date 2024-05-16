using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace FusionFPS.Managers.Client {
    [System.Serializable]
    public class ClientUIManager {
        [Header("Player UI Components")]
        public static TMP_Text ammoText, backupAmmoText;
        public Button clientButton, hostButton;

        public static ClientUIManager Instance;
        
        public void Start() {
            Instance = this;
            ammoText = GameObject.Find("AmmoText").GetComponent<TMP_Text>();
            backupAmmoText = GameObject.Find("BackupAmmoText").GetComponent<TMP_Text>();
            clientButton = GameObject.Find("ClientButton").GetComponent<Button>();
            hostButton = GameObject.Find("HostButton").GetComponent<Button>();
            clientButton.onClick.AddListener(EnterClientMode);
            hostButton.onClick.AddListener(EnterHostMode);
        }

        public static void UpdateAmmoText(uint ammo) => ammoText.text = ammo.ToString();

        public static void UpdateBackupAmmoText(uint backupAmmo) => backupAmmoText.text = backupAmmo.ToString();

        public void EnterHostMode() {
            NetworkManager.Singleton.StartHost();
            hostButton.gameObject.SetActive(false);
            clientButton.gameObject.SetActive(false);
        }

        public void EnterClientMode() {
            NetworkManager.Singleton.StartClient();
            hostButton.gameObject.SetActive(false);
            clientButton.gameObject.SetActive(false);
        }
    }
}