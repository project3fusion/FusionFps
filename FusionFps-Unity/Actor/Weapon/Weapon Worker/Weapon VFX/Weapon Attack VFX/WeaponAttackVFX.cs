using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusionFPS.Actors.Weapons.Workers {
    public class WeaponAttackVFX {
        private WeaponVFX weaponVFX;

        private GameObject muzzleVFXGameObject;

        private List<ParticleSystem> muzzleVFXParticleSystems;

        private bool isStopped;

        public WeaponAttackVFX(WeaponVFX weaponVFX) {
            this.weaponVFX = weaponVFX;
            muzzleVFXGameObject = weaponVFX.weaponWorker.weapon.weaponSettings.attackVFXGameObject;
            muzzleVFXParticleSystems = new List<ParticleSystem>();
            foreach (Transform child in muzzleVFXGameObject.transform) {
                ParticleSystem particleSystem = child.GetComponent<ParticleSystem>();
                if (particleSystem != null) muzzleVFXParticleSystems.Add(particleSystem);
            }
        }

        public void PlaySingleAttackVFX() {
            foreach (ParticleSystem particleSystem in muzzleVFXParticleSystems) {
                particleSystem.Stop();
                particleSystem.Clear();
                particleSystem.Play();
            }
        }

        public void PlayMultiAttackVFX() {
            isStopped = false;
            weaponVFX.weaponWorker.weapon.StartCoroutine(PlayAttackVFXIteration());
        }

        public IEnumerator PlayAttackVFXIteration() {
            PlaySingleAttackVFX();
            yield return new WaitForSeconds(0.2f);
            if (!isStopped) weaponVFX.weaponWorker.weapon.StartCoroutine(PlayAttackVFXIteration());
        }

        public void StopMultiAttackVFX() => isStopped = true;
    }
}