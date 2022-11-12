using System;
using Creatures;
using Core;
using UnityEngine;
using Core.Movement;

namespace Player
{
    public class PlayerController : MonoBehaviour, ISwimmable {
        
        private Mover _mover;
        private AirController _air;

        private void OnGUI()
        {
            // TODO: как блять сделать так, чтобы он уменьшался слева направо, а не справа налево?
            // Нужно играться с позиционированием по х и шириной, мб просто двигать его направо. щас так и работает
            GUI.Box(new Rect(   0.95f * Screen.width - _air.Left, 0.1f * Screen.height, _air.Capacity * 2, 30), "");
        }
        
        void Start()
        {
            _mover = GetComponent<Mover>();
            _air = GetComponent<AirController>();
        }
        
        void Update()
        {
            Move();
        }

        private void FixedUpdate()
        {
            CheckAir();
        }

        private void CheckAir()
        {
            _air.UpdateAirCapacity();
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
