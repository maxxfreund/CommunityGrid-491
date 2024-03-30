using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{

    public float moveSpeed = 15;
    private readonly float deadZone = -50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.back);

        if (transform.position.z < deadZone){
            Destroy(gameObject);
        }
    }
}
