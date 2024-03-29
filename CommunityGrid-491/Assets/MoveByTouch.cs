using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody chassis;
    public float turnSpeed;
    public float rotateSpeed;
    public Vector3 yRotVector;

    public LeftBtn leftBtn;
    public RightBtn rightBtn;

    public Camera cam;
    private float clampSideDistance;
    Vector3 startingXPos;
    Vector3 startingYRot;
    private Vector3 currXPos;
    private Vector3 currYRot;

    private float clampRotation;
    private float rotationTolerance;

    /*
        Method that initializes movement limitations of car based on screen size  
    */
    void Start() {
        clampSideDistance = 0.45f;
        clampRotation = 40f;
        rotationTolerance = 2.0f;
        startingXPos = cam.WorldToViewportPoint(transform.position);
        startingYRot = chassis.transform.rotation.eulerAngles;
    }

    /*
        Method that runs a fixed number of times per frame so that physics calculations are accurate.
        Handles the touch based Left/Right button inputs, and turns the car accordingly.
    */
    void FixedUpdate() {

        currXPos = FindXPos();
        currYRot = FindYRot();

        HandleCarBounds(currXPos);

        if (LeftBtn.LeftBtnDown){
            // Debug.Log("TURN LEFT");
            LeftTurn(currXPos, currYRot);
        }
        else if (RightBtn.RightBtnDown){
            // Debug.Log("TURN RIGHT");
            RightTurn(currXPos, currYRot);
        }
        else{
            DriveStraight(currYRot);
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

    Vector3 FindYRot(){
        Vector3 currYrot = chassis.transform.rotation.eulerAngles;
        // Debug.Log("Current y rotation: " + currYrot.y);
        return currYrot;
    }

    void LeftTurn(Vector3 currentX, Vector3 currYrot){
        if (currentX.x > startingXPos.x - clampSideDistance){
            // transform.Translate(Time.deltaTime * turnSpeed * Vector3.left);
            chassis.AddForce(Time.deltaTime * turnSpeed * Vector3.left);
            if (currYrot.y > startingYRot.y - clampRotation){
                chassis.transform.Rotate(Time.deltaTime * rotateSpeed * -yRotVector);
            }
        }
        // Debug.Log("currntX: " + currentX.x);
    }

    void RightTurn(Vector3 currentX, Vector3 currYrot){
        if (currentX.x < startingXPos.x + clampSideDistance){
            // transform.Translate(Time.deltaTime * turnSpeed * Vector3.right);
            chassis.AddForce(Time.deltaTime * turnSpeed * Vector3.right);
            if (currYrot.y < startingYRot.y + clampRotation){
                chassis.transform.Rotate(Time.deltaTime * rotateSpeed * yRotVector);
            }
        }
        // Debug.Log("currntX: " + currentX.x);
    }

    /*
        Causes car to face forward if no buttons are pressed
    */
    void DriveStraight(Vector3 currYrot){
        if (currYrot.y < startingYRot.y - rotationTolerance){
            chassis.transform.Rotate(Time.deltaTime * rotateSpeed * yRotVector);
        }
        else if (currYrot.y > startingYRot.y + rotationTolerance){
            chassis.transform.Rotate(Time.deltaTime * rotateSpeed * -yRotVector);
        }
    }

    /*
        If vehicle is outside of screen bounding area, stop its velocity 
    */
    void HandleCarBounds(Vector3 currentX){
        if ((currentX.x < startingXPos.x - clampSideDistance) || (currentX.x > startingXPos.x + clampSideDistance)){
            chassis.velocity = Vector3.zero;

            //maybe get rid of this one if it breaks drift turning
            chassis.angularVelocity = Vector3.zero;
        }
    }
}
