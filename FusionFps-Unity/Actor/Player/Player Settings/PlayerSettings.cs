using UnityEngine;

namespace FusionFPS.Actors.Players {
    [System.Serializable]
    public class PlayerSettings {
        [Header("Player SFX Settings")]
        public AudioClip walkSFX;
        public AudioClip runSFX;
        public AudioSource footSFXAudioSource;
        [Header("Player Inventory Settings")]
        public GameObject dumbRifle;
    }
}