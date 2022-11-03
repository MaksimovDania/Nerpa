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

    [SerializeField] private Joystick _joystick;

    private Rigidbody _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private float Abs(float value)
    {
        return value >= 0 ? value : -value;
    }
    
    public void StopMove()
    {
        
        if (Abs(_rigidbody.velocity.x) > 0.001 || Abs(_rigidbody.velocity.y) > 0.001)
            _rigidbody.AddForce(-_rigidbody.velocity * 2);
    }

    public void MoveTowardsDirection()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");

        var moveVertical = Input.GetAxis("Vertical");
        
        if (_joystick)
        {
            moveHorizontal = _joystick.Horizontal;
        
            moveVertical = _joystick.Vertical;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
         // if (Abs(_rigidbody.velocity.x) < maxSpeed && Abs(_rigidbody.velocity.y) < maxSpeed)
            _rigidbody.AddForce(movement * boost, ForceMode.Acceleration);
            
    }
}
