using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveByTouch : MonoBehaviour
{
    public Rigidbody car;
    public float turnSpeed;

    public LeftBtn leftBtn;
    public RightBtn rightBtn;

    // public GameObject leftBtn;
    // public GameObject rightBtn;
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

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }

    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }
}
