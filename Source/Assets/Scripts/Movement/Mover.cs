using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Range(1f, 20f)]
    [SerializeField] private float boost;

    [Range(1f, 5f)]
    [SerializeField] private float maxSpeed;
    
    [SerializeField] private Transform canvas;
    
    [SerializeField] private GameObject joystick;
    
    [Range(1f, 5f)]
    [SerializeField] private float stopSpeed;
    
    private GameObject _joystick;
    private Joystick _joystickComponent;
    
    private Rigidbody _rigidbody;
    
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _joystick = Instantiate(joystick, canvas);
        _joystickComponent = _joystick.GetComponent<Joystick>();
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
            var movement = new Vector3(_joystickComponent.Direction.x, _joystickComponent.Direction.y, 0f);
            _rigidbody.AddForce(movement * boost);
        }
    }
    
    private float Abs(float value)
    {
        return value > 0 ? value : -value;
    }

}
