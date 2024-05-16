using System.Collections;
using UnityEngine;

namespace FusionFPS.Actors.Players.Workers {
    public class PlayerAttack {
        private PlayerWorker playerWorker;

        public bool isAttacking, isMultiAttackModeEnabled, isStopped;

        public bool isAttackQueueCooldown, isAttackModeChangeCooldown, isAddQueueCooldown;

        private int queuedAttackCount, maxQueuedAttackCount = 1;

        public PlayerAttack(PlayerWorker playerWorker) => this.playerWorker = playerWorker;

        public void ServerUpdate() {
            if (!playerWorker.player.isPlayerFunctional) return;
            else if (
                !isAttacking && 
                !isAttackQueueCooldown && 
                queuedAttackCount > 0) Attack();
            else if (
                !isAttackQueueCooldown && 
                !isAttacking && 
                queuedAttackCount == 0 &&
                isMultiAttackModeEnabled && 
                !isStopped) StopAttack();
        }

        public void AttackRequest() {
            if (!playerWorker.player.isPlayerFunctional) return;
            else if (isMultiAttackModeEnabled) MultiAttackRequest();
            else SingleAttackRequest();
        }

        public void AttackModeChangeRequest() {
            if (!playerWorker.player.isPlayerFunctional || isAttackModeChangeCooldown) return;
            playerWorker.player.PlayerStopAttackClientRpc();
            queuedAttackCount = 0;
            isMultiAttackModeEnabled = !isMultiAttackModeEnabled;
            playerWorker.player.StartCoroutine(ResetAttackModeChangeCooldown());
            playerWorker.player.PlayerAttackModeChangeClientRpc();
        }

        public void SingleAttackRequest() {
            if (isAttacking || 
            queuedAttackCount > 0 || 
            isAttackQueueCooldown || 
            !playerWorker.playerWeapon.isWeaponReadyToAttack ||
            isAddQueueCooldown ||
            !playerWorker.player.isPlayerFunctional) return;
            queuedAttackCount++;
        }

        public void MultiAttackRequest() {
            if (queuedAttackCount >= maxQueuedAttackCount || 
            !playerWorker.playerWeapon.isWeaponReadyToAttack ||
            isAddQueueCooldown ||
            !playerWorker.player.isPlayerFunctional) return;
            queuedAttackCount++;
            playerWorker.player.StartCoroutine(ResetAddQueueCooldown());
        }

        public IEnumerator ResetAttackQueueCooldown() {
            isAttackQueueCooldown = true;
            yield return new WaitForSeconds(isMultiAttackModeEnabled ? 0.14f : 0.5f);
            isAttackQueueCooldown = false;
        }

        public IEnumerator ResetAttackModeChangeCooldown() {
            isAttackModeChangeCooldown = true;
            yield return new WaitForSeconds(0.5f);
            isAttackModeChangeCooldown = false;
        }

        public IEnumerator ResetAddQueueCooldown() {
            isAddQueueCooldown = true;
            yield return new WaitForSeconds(0.05f);
            isAddQueueCooldown = false;
        }
        
        public void Attack() {
            if(!playerWorker.playerWeapon.weapon.weaponWorker.weaponStats.CheckAmmo()) {
                queuedAttackCount = 0;
                if (!isStopped) StopAttack();
                playerWorker.player.PlayerNoAmmoClientRpc();
                return;
            }
            isAttacking = true;
            queuedAttackCount--;
            playerWorker.playerPool.playerAttackPool.GetProjectile();
            if (isMultiAttackModeEnabled) {
                if (isStopped) playerWorker.player.PlayerMultiAttackClientRpc();
                playerWorker.playerAnimation.AttackAnimationRequest(true, true);
                isStopped = false;
            }
            else {
                if (!isStopped) {
                    playerWorker.player.PlayerStopAttackClientRpc();
                    playerWorker.playerAnimation.AttackAnimationRequest(true, false);
                }
                playerWorker.player.PlayerSingleAttackClientRpc();
                playerWorker.playerAnimation.AttackAnimationRequest(false, true);
                isStopped = true;
            }
            playerWorker.player.StartCoroutine(ResetAttackQueueCooldown());
            isAttacking = false;
        }

        public void StopAttack() {
            playerWorker.player.PlayerStopAttackClientRpc();
            playerWorker.playerAnimation.AttackAnimationRequest(true, false);
            isStopped = true;
        }
    }
}