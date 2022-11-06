using UnityEngine;
using Core;


namespace Creatures 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LittleFish : MonoBehaviour, ISwimmable 
    {
        [SerializeField] private float speed;

        private Rigidbody2D _rigidbody;
        private float _timer;

        private void Start() 
        {
            _timer = 0f;
            _rigidbody = GetComponent<Rigidbody2D>();
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
            _rigidbody.AddForce(Mover.GetRandomDirection() * speed);
        }
        
	}
}

