using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    private int score = 0;

    private int numCoinsCollected = 0;

    public int numCoinsInLevel = 1;

    public ScoreBar scorebar;

    public TextMeshProUGUI winMessage;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCoins(){
        return numCoinsCollected;
    }

    public void AddScore(int value){
        score += value;
        numCoinsCollected += 1;
        scorebar.UpdateScoreBar(numCoinsCollected);

        CheckEndGame();
    }

    public void CheckEndGame() {
        if(numCoinsCollected == numCoinsInLevel){
            EndGame();
        }
    }

    public void EndGame(){
        if(numCoinsCollected == numCoinsInLevel){
            winMessage.SetText("You Won");
        }else{
            winMessage.SetText("You Lose");
        }

        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
