using UnityEngine;
using Core;


namespace Creatures 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LittleFish : MonoBehaviour, ISwimmable
    {
		[SerializeField] private float speed;

        private Rigidbody2D _rigidbody;
        private Reaction reaction;
        

		private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Messenger.AddListener(Timer.action, Move);
            Move();
        }

		private void FixedUpdate()
		{
            if (reaction != null)
                reaction.Tick();
		}

		public void Move() {
            _rigidbody.AddForce(Mover.GetRandomDirection() * speed);
        }

        public void Move(Vector2 direction)
        {
			_rigidbody.AddForce(direction * speed * 2f);
		}

        public void React(Vector3 direction)
        {
            if (reaction == null || reaction.timer <= 0f)
            {
                Move(direction);
                reaction = new Reaction(8f);
            }
        }

        private void OnApplicationQuit() 
        {
            RemoveListener();
		}

        public void RemoveListener()
        {
			Messenger.RemoveListener(Timer.action, Move);
		}
    }

    public class Reaction
    {
		public float timer;

        public Reaction(float time)
        {
            this.timer = time;
        }

        public void Tick()
        {
            if (timer > 0f)
            {
				timer -= Time.deltaTime;
            }
        }
    }

}

