using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using FusionFPS.Actors.Players.Workers;
using FusionFPS.Actors.Components;

namespace FusionFPS.Actors.Players {
    public class Player : Actor, ITarget, ITargeter {
        public PlayerWorker playerWorker;

        public PlayerSettings playerSettings;

        public NetworkVariable<uint> ammo = new NetworkVariable<uint>(0);
        public NetworkVariable<uint> backupAmmo = new NetworkVariable<uint>(0);
        public NetworkVariable<Quaternion> rotation = new NetworkVariable<Quaternion>(Quaternion.identity);

        public bool isDead, isReady, isBlocked;

        public override void OnNetworkSpawn() {
            base.OnNetworkSpawn();
            playerWorker = new PlayerWorker(this);
            playerWorker.Start();
            isReady = true;
        }

        public void RecieveDamage(float damage) => 
            playerWorker.playerEvent.OnPlayerDamage(damage);

        public void SendDamage(float damage, Actor target) {

        }

        public void Update() {
            if(isPlayerFunctional) playerWorker.Update();
        }

        public void LateUpdate() {
            if(isPlayerFunctional) playerWorker.LateUpdate();
        }

        public bool isPlayerFunctional => !isDead && isReady && !isBlocked;

        [ServerRpc] public void PlayerAttackRequestServerRpc() => 
            playerWorker.playerAttack.AttackRequest();

        [ServerRpc] public void PlayerAttackModeChangeRequestServerRpc() =>
            playerWorker.playerAttack.AttackModeChangeRequest();

        [ServerRpc] public void PlayerMovementRequestServerRpc(Vector2 movementInput, bool sprintInput) =>
            playerWorker.playerMovement.MovementRequest(movementInput, sprintInput);

        [ServerRpc] public void PlayerReloadRequestServerRpc() =>
            playerWorker.playerWeapon.ReloadAmmo();

        [ServerRpc] public void PlayerRotationRequestServerRpc(Vector2 rotationInput) =>
            playerWorker.playerRotation.RotationRequest(rotationInput);

        [ClientRpc] public void PlayerSingleAttackClientRpc() {
            playerWorker.playerVFX.playerAttackVFX.PlaySingleAttackVFX();
            playerWorker.playerSFX.playerAttackSFX.PlaySingleAttackSFX();
        }

        [ClientRpc] public void PlayerMultiAttackClientRpc() {
            playerWorker.playerVFX.playerAttackVFX.PlayMultiAttackVFX();
            playerWorker.playerSFX.playerAttackSFX.PlayMultiAttackSFX();
        }

        [ClientRpc] public void PlayerStopAttackClientRpc() {
            playerWorker.playerVFX.playerAttackVFX.StopAttackVFX();
            playerWorker.playerSFX.playerAttackSFX.StopAttackSFX();
        }

        [ClientRpc] public void PlayerAttackModeChangeClientRpc() =>
            playerWorker.playerSFX.playerAttackSFX.PlayAttackModeChangeSFX();

        [ClientRpc] public void PlayerNoAmmoClientRpc() =>
            playerWorker.playerSFX.playerAttackSFX.PlayNoAmmoSFX();
    }
}