using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody chassis;
    public float turnSpeed;

    public LeftBtn leftBtn;
    public RightBtn rightBtn;

    public Camera cam;
    private float clampSideDistance;
    Vector3 startingXPos;
    private Vector3 currXPos;

    /*
        Method that initializes movement limitations of car based on screen size  
    */
    void Start() {
        clampSideDistance = 0.45f;
        startingXPos = cam.WorldToViewportPoint(transform.position);
    }

    /*
        Method that runs a fixed number of times per frame so that physics calculations are accurate.
        Handles the touch based Left/Right button inputs, and turns the car accordingly.
    */
    void FixedUpdate() {

        currXPos = FindXPos();

        HandleCarBounds(currXPos);

        if (LeftBtn.LeftBtnDown){
            // Debug.Log("TURN LEFT");
            LeftTurn(currXPos);
        }
        else if (RightBtn.RightBtnDown){
            // Debug.Log("TURN RIGHT");
            RightTurn(currXPos);
        }
        else{

        }
    }

    /*
        Uses viewport of camera to determine current x position of car (from 0 to 1)
    */
    Vector3 FindXPos(){
        // Vector3 currentX = cam.WorldToViewportPoint(transform.position);
        Vector3 currentX = cam.WorldToViewportPoint(chassis.position);
        // return currentX.x;
        return currentX;
    }

    void LeftTurn(Vector3 currentX){
        if (currentX.x > startingXPos.x - clampSideDistance){
            // transform.Translate(Time.deltaTime * turnSpeed * Vector3.left);
            chassis.AddForce(Time.deltaTime * turnSpeed * Vector3.left);
        }
        Debug.Log("currntX: " + currentX.x);
    }

    void RightTurn(Vector3 currentX){
        if (currentX.x < startingXPos.x + clampSideDistance){
            // transform.Translate(Time.deltaTime * turnSpeed * Vector3.right);
            chassis.AddForce(Time.deltaTime * turnSpeed * Vector3.right);
        }
        Debug.Log("currntX: " + currentX.x);
    }

    /*
        If vehicle is outside of screen bounding area, stop it's velocity 
    */
    void HandleCarBounds(Vector3 currentX){
        if ((currentX.x < startingXPos.x - clampSideDistance) || (currentX.x > startingXPos.x + clampSideDistance)){
            chassis.velocity = Vector3.zero;

            //maybe get rid of this one if it breaks drift turning
            chassis.angularVelocity = Vector3.zero;
        }
    }
}
