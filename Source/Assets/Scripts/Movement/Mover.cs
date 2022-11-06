using Core;
using Creatures;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Range(1f, 20f)] [SerializeField] private float boost;
    [Range(1f, 5f)] [SerializeField] private float maxSpeed;
    [Range(1f, 5f)] [SerializeField] private float fishSpeed;
    [Range(1f, 5f)] [SerializeField] private float stopSpeed;

    [Header ("Additional tools")]
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject joystick;
    
    private GameObject _joystick;
    private Joystick _joystickComponent;
    private Rigidbody2D _rigidbody;
    
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (TryGetComponent(out Player.PlayerController nerpa))
        {
            _joystick = Instantiate(joystick, canvas);
            _joystickComponent = _joystick.GetComponent<Joystick>();
        }
    }

    public void StopMove()
    {
        if (Abs(_rigidbody.velocity.x) > 0.001f || Abs(_rigidbody.velocity.y) > 0.001f)
            _rigidbody.AddForce(-_rigidbody.velocity * stopSpeed);
    }

    public void MoveTowardsDirection()
    {
        if (_joystick)
        {
            if (_rigidbody.velocity.magnitude >= maxSpeed)
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;

            _rigidbody.AddForce(_joystickComponent.Direction * boost);
        }
    }
    
    public void MoveFish() => _rigidbody.AddForce(GetRandomDirection() * fishSpeed);

    private Vector2 GetRandomDirection() => new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    
    private float Abs(float value) => value > 0 ? value : -value;

}
