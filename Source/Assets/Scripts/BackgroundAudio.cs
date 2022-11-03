using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core {

    [RequireComponent(typeof(AudioSource))]
    public class BackgroundAudio : MonoBehaviour {
        [SerializeField] private AudioClip soundtrack;
        [SerializeField] private float fadeSpeed;
        public static AudioSource audioSource;
        public static BackgroundAudio instance { get; private set; }

        void Awake() {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        private void Start() {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundtrack;
            audioSource.volume = 0f;
            audioSource.Play();
        }

		private void FixedUpdate() {
            if (!audioSource.mute && audioSource.volume != 1f)
                audioSource.volume += Time.deltaTime * fadeSpeed;
            else if (audioSource.mute && audioSource.volume != 0f)
                audioSource.volume -= Time.deltaTime * fadeSpeed;
        }

		public void Play() {
            if (audioSource != null)
                audioSource.mute = false;
        }

        public void Mute() {
            if (audioSource != null)
                audioSource.mute = true;
        }
    }

}