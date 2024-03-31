using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;

    public float counter = 2;
    private float timer = 0;
    public void AddScore(){
        //TEMP
        if (timer < counter){
            timer += Time.deltaTime;
        }
        else{
            playerScore++;
            scoreText.text = playerScore.ToString();
            timer = 0;
        }
        //
    }

    void Update(){
        //TEMP
        if (timer < counter){
            timer += Time.deltaTime;
        }
        else{
            playerScore++;
            scoreText.text = playerScore.ToString();
            timer = 0;
        }
        //
    }
}
