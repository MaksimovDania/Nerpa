using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Core {

    public enum States {
        TRAINING, SPRING, SUMMER, AUTUMN, WINTER, END
    }

    public class SceneController : MonoBehaviour {

        [SerializeField] public States state;
        [SerializeField] private List<State> stateList;

        private State currentState;
        public static SceneController instance;


        void Awake() {
            if (instance == null)
                instance = this;
        }

        void Start() {
            SetState(stateList[(int)state]);
        }

        void Update() {

            if (currentState != stateList[(int)state])
                SetState(stateList[(int)state]);

            currentState.Update();
        }

        void OnDestroy() {
            currentState?.Exit();
        }

        public void NextLevel() {
            state++;
            SetState(stateList[(int)state]);
        }

        public void PrevLevel() {
            state--;
            SetState(stateList[(int)state]);
        }

        public void SetState(State nextState) {
            currentState?.Exit();
            currentState = nextState;
            currentState.Enter();
        }

        public int GetState() => (int)state;

        //public void BackToMenu() => SceneManager.LoadScene(GlobalPrefs.menuScene);

    }
}
