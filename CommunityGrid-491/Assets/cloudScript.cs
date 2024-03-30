using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class cloudScript : MonoBehaviour
{
    public float bobSpeed = 5f;
    public float bobHeight = 0.25f;
    Vector3 pos;

    void Start(){
        pos = transform.position;
    }
    void Update()
    {
        float newY = Mathf.Sin(Time.time * bobSpeed) * bobHeight + pos.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);        
    }
}
