using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        
        private Mover _mover;

        // Start is called before the first frame update
        void Start()
        {
            _mover = GetComponent<Mover>();
        }

        // Update is called once per frame
        void Update()
        {
            ProcessInput();
        }
        
        private void ProcessInput()
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
            {
                _mover.MoveTowardsDirection();
            }
            else
            {
                _mover.StopMove();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            print("Collided");
            if (collision.collider.CompareTag("Fish"))
            {
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
