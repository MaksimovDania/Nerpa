using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;


namespace Creatures {

    [RequireComponent(typeof(Rigidbody))]
    public class LittleFish : MonoBehaviour, IFish {
        
        [SerializeField] private float speed;

        private Rigidbody _rigidbody;
        private Mover _mover;
        private float timer;

        void Start() {
            timer = 0f;
            _rigidbody = GetComponent<Rigidbody>();
            Move();
        }

		private void LateUpdate() {
			if (timer > 8f) {
                Move();
                timer = 0f;
            }
            timer += Time.deltaTime;
		}

        public void Move() {
            (float horizontalForce, float verticalForce) = GetRandomDirection();
            var movement = new Vector3(horizontalForce, verticalForce, 0.0f);
            _rigidbody.AddForce(movement * speed);
        }

        private (float, float) GetRandomDirection() {
            return (Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        void OnCollisionEnter(Collision collision) {
        }

        void OnCollisionExit(Collision collision) {
        }
	}
}

