using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody car;
    public float turnSpeed;

    public bool Left;
    public bool Right;
    private float screenWidth;

    void Start() {
        screenWidth = Screen.width;
    }

    // void Update()
    // {
    //     // if (Input.GetMouseButtonDown(0)){
    //     //     car.velocity = Vector2.up * 5; 
    //     // }


    // }

    void FixedUpdate() {
        // if (tapLeft()){
        //     car.AddForce(new Vector3(horizontalInput * turnSpeed * Time.deltaTime, 0, 0));
        // }
        // else if (tapRight()){

        // }
        // else{

        // }
    }
}
