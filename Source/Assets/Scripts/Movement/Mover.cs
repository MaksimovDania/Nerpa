using System.Collections;
using System.Collections.Generic;
using Core;
using Creatures;
using UnityEngine;
using static System.Random;

public class Mover : MonoBehaviour
{
    [Range(1f, 20f)]
    [SerializeField] private float boost;

    [Range(1f, 5f)]
    [SerializeField] private float maxSpeed;
    
    [Range(1f, 5f)]
    [SerializeField] private float fishSpeed;
    
    [SerializeField] private Transform canvas;
    
    [SerializeField] private GameObject joystick;
    
    [Range(1f, 5f)]
    [SerializeField] private float stopSpeed;
    
    private GameObject _joystick;
    private Joystick _joystickComponent;
    private Rigidbody2D _rigidbody;
    
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (!TryGetComponent(out LittleFish fish))
        {
            _joystick = Instantiate(joystick, canvas);
            _joystickComponent = _joystick.GetComponent<Joystick>();
        }
    }

    public void StopMove()
    {
        if (Abs(_rigidbody.velocity.x) > 0.001 || Abs(_rigidbody.velocity.y) > 0.001)
            _rigidbody.AddForce(-_rigidbody.velocity * stopSpeed);
    }

    public void MoveTowardsDirection()
    {
        if (_joystick)
        {
            if (_rigidbody.velocity.magnitude >= maxSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
            }
            var movement = new Vector2(_joystickComponent.Direction.x, _joystickComponent.Direction.y);
            _rigidbody.AddForce(movement * boost);
        }
    }
    
    public void MoveFish() 
    {
        (float horizontalForce, float verticalForce) = GetRandomDirection();
        var movement = new Vector2(horizontalForce, verticalForce);
        _rigidbody.AddForce(movement * fishSpeed);
    }

    private (float, float) GetRandomDirection() 
    {
        return (Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
    
    private float Abs(float value)
    {
        return value > 0 ? value : -value;
    }

}
