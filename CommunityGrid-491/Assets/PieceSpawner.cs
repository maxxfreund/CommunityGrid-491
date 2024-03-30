using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject piece1;
    public float spawnRate;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPiece(piece1);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            SpawnPiece(piece1);
            timer = 0;
        }
    }

    void SpawnPiece(GameObject piece){
        Instantiate(piece, transform.position, transform.rotation);
    }
}
