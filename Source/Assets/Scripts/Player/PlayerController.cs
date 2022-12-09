using Creatures;
using Core;
using UnityEngine;
using System.Collections.Generic;

namespace Player
{
    public class PlayerController : MonoBehaviour, ISwimmable {
        private Mover _mover;
        [SerializeField] [Range (0f, 25f)] private float distanceToFish;

        void Start()
        {
            _mover = GetComponent<Mover>();
        }

        void Update()
        {
            Move();
        }

        void FixedUpdate()
        {
            DetectFish();
		}
        
        public void Move()
        {
            if (Input.GetMouseButton(0))
                _mover.MoveTowardsDirection();
            else
                _mover.StopMove();
        }

        public void DetectFish()
        {
            ReactToNerpa(FishSpawner.instance.bullfishs);
			ReactToNerpa(FishSpawner.instance.oilfishs);
			ReactToNerpa(FishSpawner.instance.omuls);
		}

        private void ReactToNerpa(List<GameObject> fishs)
        {
			for (int i = 0; i < fishs.Count; i++)
			{
				if (Vector2.Distance(transform.position, fishs[i].transform.position) <= distanceToFish)
				{
					Vector3 forceDirection = (fishs[i].transform.position - transform.position).normalized;
					fishs[i].GetComponent<LittleFish>().React(forceDirection);
				}
			}
		}

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Omul"))
            {
                FishSpawner.instance.RemoveFish(collision.collider.gameObject, FishSpawner.instance.omuls);
                collision.collider.gameObject.GetComponent<LittleFish>().RemoveListener();
				Destroy(collision.collider.gameObject);
            } 
            else if (collision.collider.CompareTag("OilFish")) 
            {
                FishSpawner.instance.RemoveFish(collision.collider.gameObject, FishSpawner.instance.oilfishs);
				collision.collider.gameObject.GetComponent<LittleFish>().RemoveListener();
				Destroy(collision.collider.gameObject);
            } 
            else if (collision.collider.CompareTag("BullFish")) 
            {
                FishSpawner.instance.RemoveFish(collision.collider.gameObject, FishSpawner.instance.bullfishs);
				collision.collider.gameObject.GetComponent<LittleFish>().RemoveListener();
				Destroy(collision.collider.gameObject);
            }
        }
	}
}
