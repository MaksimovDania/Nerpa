using UnityEngine;


namespace Core {
    [RequireComponent(typeof(AudioSource))]
    public class Clicker : MonoBehaviour {
        public static Clicker instance;
        public bool clickable;

        void Awake() {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        void Update() {
            if (Input.anyKeyDown && clickable)
                GetComponent<AudioSource>().Play();
        }
    }
}
