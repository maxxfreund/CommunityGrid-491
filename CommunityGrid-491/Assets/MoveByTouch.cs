using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody car;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            car.velocity = Vector2.up * 5; 
        }
    }
}
