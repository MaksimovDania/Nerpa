using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class AirController : MonoBehaviour
{
    [Range(10f, 200f)]
    [SerializeField]
    private float airCapacity; // maximum air we have
    
    [SerializeField]
    public Transform WaterLevel;
    
    [SerializeField]
    private float airLeft;
    
    public float Capacity => airCapacity; // maybe will be needed
    
    
    
    public float Left => airLeft;
    


    private void Start()
    {
        airLeft = airCapacity;
    }

    public void UpdateAirCapacity()
    {
        if (gameObject.transform.position.y <= WaterLevel.position.y - 2)
        {
            if (airLeft > 0)
            {
                airLeft -= Time.deltaTime;
            }
            else
            {
                NoAirLeft();
            }
        }
        else
        {
            if (airLeft < 100)
            {
                airLeft += Time.deltaTime * 3;
            }
        }

    }
    
    private void NoAirLeft()
    {
        // screen become darker and darker
        // than we die
        // how to make screen dark with time: https://www.youtube.com/watch?v=U-4kVK9wpPA
    }
}
