using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core {

    public abstract class State : ScriptableObject {

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();

        public void print(object str) => Debug.Log(str);
    }

}
