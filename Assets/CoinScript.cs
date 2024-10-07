using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject gameManagerObject;

    public GameManager gameManager;

    private int coinValue = 1;

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if(gameManagerObject == null) gameManagerObject = GameObject.FindWithTag("GameController");

        if(gameManagerObject != null){
            gameManager = gameManagerObject.GetComponent<GameManager>();
        } else{
            Debug.LogError("Game Manager not found");
        }

        ScoreBar.maxTokens++;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            if(gameManager != null){
                gameManager.AddScore(coinValue);

                gameObject.SetActive(false);
                audioManager.PlaySFX(audioManager.coinGet);
            }
        } else{
            Debug.LogError("game manager reference missing");
        }
    }
}
