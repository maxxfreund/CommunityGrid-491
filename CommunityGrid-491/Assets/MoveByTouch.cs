using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody car;
    public float turnSpeed;

    public LeftBtn leftBtn;
    public RightBtn rightBtn;

    public Camera cam;
    public float clampSideDistance;
    Vector3 startingXPos;
    private float currXPos;

    void Start() {
        // screenWidth = Screen.width;
        clampSideDistance = 0.45f;
        startingXPos = cam.WorldToViewportPoint(transform.position);

        // Debug.Log("Screen width: " + screenWidth);
        Debug.Log("clampSideDistance: " + clampSideDistance);
        Debug.Log("startingXPos.x: " + startingXPos.x);
    }

    void FixedUpdate() {

        currXPos = FindXPos();

        if (LeftBtn.LeftBtnDown){
            Debug.Log("TURN LEFT");
            // car.AddForce(new Vector3(-1.0f * turnSpeed * Time.deltaTime, 0, 0));
            LeftTurn(currXPos);
        }
        else if (RightBtn.RightBtnDown){
            Debug.Log("TURN RIGHT");
            // car.AddForce(new Vector3(1.0f * turnSpeed * Time.deltaTime, 0, 0));
            RightTurn(currXPos);
        }
        else{

        }
    }

    float FindXPos(){
        Vector3 currentX = cam.WorldToViewportPoint(transform.position);
        return currentX.x;
    }

    void LeftTurn(float currentX){
        if (currentX > startingXPos.x - clampSideDistance){
            transform.Translate(Time.deltaTime * turnSpeed * Vector3.left);
        }
    }

    void RightTurn(float currentX){
        if (currentX < startingXPos.x + clampSideDistance){
            transform.Translate(Time.deltaTime * turnSpeed * Vector3.right);
        }
    }
}
