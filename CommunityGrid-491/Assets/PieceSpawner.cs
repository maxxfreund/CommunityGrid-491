using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject[] pieces;
    public float spawnRate;
    private float timer = 0;

    private int minIndex;
    private int maxIndex;
    private int indexPick;
    private Vector3 piece3offset = new(0, 0, 6);

    /*
        Initializes min and max indexes for the array of pieces,
        and spawns initial piece.
    */
    void Start()
    {
        minIndex = 0;
        maxIndex = pieces.Length;
        indexPick = IndexPicker();
        SpawnPiece(indexPick);
    }

    /*
        Spawns a new random piece based on the timer
    */
    void Update()
    {
        if (timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            indexPick = IndexPicker();
            SpawnPiece(indexPick);
            timer = 0;
        }
    }

    void SpawnPiece(int i){
        if (i == 2){
            Instantiate(pieces[i], transform.position + piece3offset, transform.rotation);
        }
        else{
            Instantiate(pieces[i], transform.position, transform.rotation);
        }
    }

    int IndexPicker(){
        return Random.Range(minIndex, maxIndex);
    }
}
