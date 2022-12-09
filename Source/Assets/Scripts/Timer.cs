using Creatures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Core
{
    public class Timer : MonoBehaviour
    {
        public static Timer instance { get; private set; }
        public static float timer;
        public static string action = "Make action";


        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            timer = 0f;
        }

        private void FixedUpdate()
        {
            if (timer > 8f)
                ResetTimer();

			timer += Time.deltaTime;
        }

		private void ResetTimer()
		{
            Messenger.Broadcast(action);
			timer = 0f;
		}
	}
}
