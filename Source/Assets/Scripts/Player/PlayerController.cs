using Creatures;
using Core;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour, ISwimmable {
        private Mover _mover;

        void Start()
        {
            _mover = GetComponent<Mover>();
        }

        void Update()
        {
            Move();
        }
        
        public void Move()
        {
            if (Input.GetMouseButton(0))
                _mover.MoveTowardsDirection();
            else
                _mover.StopMove();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Fish"))
            {
                Destroy(collision.collider.gameObject);
            }
        }
	}
}
