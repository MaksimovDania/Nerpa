using UnityEngine;


namespace Core {
    [RequireComponent(typeof(AudioSource))]
    public class Clicker : MonoBehaviour {
        public static Clicker instance;
        public bool clickable;

        private AudioSource _audio;
        void Awake() {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
            _audio = GetComponent<AudioSource>();
        }

        void Update() {
            if (Input.anyKeyDown && clickable)
                _audio.Play();
        }
    }
}
