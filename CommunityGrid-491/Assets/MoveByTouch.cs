using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody car;
    public float turnSpeed;

    public LeftBtn leftBtn;
    public RightBtn rightBtn;
    private float screenWidth;

    void Start() {
        screenWidth = Screen.width;
    }

    void FixedUpdate() {
        if (LeftBtn.LeftBtnDown){
            Debug.Log("TURN LEFT");
            // car.AddForce(new Vector3(-1.0f * turnSpeed * Time.deltaTime, 0, 0));
            transform.Translate(Vector3.left * turnSpeed * Time.deltaTime);
        }
        else if (RightBtn.RightBtnDown){
            Debug.Log("TURN RIGHT");
            // car.AddForce(new Vector3(1.0f * turnSpeed * Time.deltaTime, 0, 0));
            transform.Translate(Vector3.right * turnSpeed * Time.deltaTime);
        }
        else{

        }
    }
}
