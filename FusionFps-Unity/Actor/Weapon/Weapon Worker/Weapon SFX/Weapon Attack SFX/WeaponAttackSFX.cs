using UnityEngine;
using System.Collections;

namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponAttackSFX {
        private WeaponSFX weaponSFX;
        
        private AudioSource audioSource;
        private AudioClip singleAttackAudioClip, multiAttackAudioClip;
        private AudioClip noAmmoAudioClip, changeAttackModeAudioClip, reloadInsertAudioClip, reloadRemoveAudioClip;

        private bool isStarted;

        public WeaponAttackSFX(WeaponSFX weaponSFX) {
            this.weaponSFX = weaponSFX;
            audioSource = weaponSFX.weaponWorker.weapon.weaponSettings.attackSFXAudioSource;
            singleAttackAudioClip = weaponSFX.weaponWorker.weapon.weaponSettings.singleAttackAudioClip;
            multiAttackAudioClip = weaponSFX.weaponWorker.weapon.weaponSettings.multiAttackAudioClip;
            noAmmoAudioClip = weaponSFX.weaponWorker.weapon.weaponSettings.noAmmoAudioClip;
            changeAttackModeAudioClip = weaponSFX.weaponWorker.weapon.weaponSettings.changeAttackModeAudioClip;
            reloadInsertAudioClip = weaponSFX.weaponWorker.weapon.weaponSettings.reloadInsertAudioClip;
            reloadRemoveAudioClip = weaponSFX.weaponWorker.weapon.weaponSettings.reloadRemoveAudioClip;
        }

        public void PlaySingleAttackSFX() {
            audioSource.clip = singleAttackAudioClip;
            audioSource.loop = false;
            audioSource.Play();
        }

        public void PlayMultiAttackSFX() {
            if (isStarted) return;
            isStarted = true;
            audioSource.clip = multiAttackAudioClip;
            audioSource.loop = true;
            audioSource.Play();
        }

        public void StopAttackSFX() {
            audioSource.Stop();
            isStarted = false;
        }

        public void PlayNoAmmoSFX() {
            audioSource.clip = noAmmoAudioClip;
            audioSource.loop = false;
            audioSource.Play();
        }

        public void PlayAttackModeChangeSFX() {
            audioSource.clip = changeAttackModeAudioClip;
            audioSource.loop = false;
            audioSource.Play();
        }

        public void PlayReloadSFX() {
            IEnumerator FinishReloadSFX() {
                yield return new WaitForSeconds(0.5f);
                audioSource.clip = reloadInsertAudioClip;
                audioSource.loop = false;
                audioSource.Play();
            }
            audioSource.clip = reloadRemoveAudioClip;
            audioSource.loop = false;
            audioSource.Play();
            weaponSFX.weaponWorker.weapon.StartCoroutine(FinishReloadSFX());
        }
    }
}