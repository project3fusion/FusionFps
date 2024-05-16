using FusionFPS.Managers.Client;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerUI {
        private PlayerWorker playerWorker;

        public PlayerUI(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ClientOwnerUpdate() {
            UpdatePlayerWeaponStatsUI();
        }

        public void UpdatePlayerWeaponStatsUI() {
            ClientUIManager.UpdateAmmoText(playerWorker.player.ammo.Value);
            ClientUIManager.UpdateBackupAmmoText(playerWorker.player.backupAmmo.Value);
        }
    }
}