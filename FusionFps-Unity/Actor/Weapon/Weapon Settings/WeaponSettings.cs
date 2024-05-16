using UnityEngine;

namespace FusionFPS.Actors.Weapons {
    [System.Serializable]
    public class WeaponSettings {
        [Header("Weapon SFX Settings")]
        public AudioClip singleAttackAudioClip;
        public AudioClip multiAttackAudioClip;
        public AudioClip changeAttackModeAudioClip;
        public AudioClip noAmmoAudioClip;
        public AudioClip reloadInsertAudioClip;
        public AudioClip reloadRemoveAudioClip;
        public AudioSource attackSFXAudioSource;
        [Header("Weapon Stats Settings")]
        public uint ammo;
        public uint maxAvailableAmmo;
        public uint maxAmmo;
        public uint backupAmmo;
        public float reloadTime;
        [Header("Weapon VFX Settings")]
        public GameObject attackVFXGameObject;
        [Header("Weapon IK Settings")]
        public Vector3 handPosition;
        public Vector3 handRotation;
        [Header("Weapon Pool Settings")]
        public GameObject projectilePrefab;
        public int defaultCapacity;
    }
}