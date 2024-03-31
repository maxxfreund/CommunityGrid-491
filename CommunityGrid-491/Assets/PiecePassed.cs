using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PiecePassed : MonoBehaviour
{
    public PointScript pointScript;

    // Start is called before the first frame update
    void Start()
    {
        pointScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<PointScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            pointScript.AddScore();
        }
    }
}
