using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;


namespace Creatures 
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class LittleFish : MonoBehaviour, IFish 
    {
        
        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;
        private Mover _mover;
        private float _timer;

        void Start() 
        {
            _timer = 0f;
            _rigidbody = GetComponent<Rigidbody2D>();
            _mover = GetComponent<Mover>();
            Move();
        }

		private void LateUpdate() {
			if (_timer > 8f) {
                Move();
                _timer = 0f;
            }
            _timer += Time.deltaTime;
		}

        public void Move() {
            _mover.MoveFish();
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

