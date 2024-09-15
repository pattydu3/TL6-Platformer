using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    public GameObject hud;
    public bool hudOpen;

    public TextMeshProUGUI hudText;



    public GameObject gameManagerObject;

    public GameManager gameManager;

    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        hud.SetActive(false);
        gameManagerObject = GameObject.FindWithTag("GameController");

        // if(gameManagerObject != null){
        //     gameManager = gameManagerObject.GetComponent<GameManager>();
        // } else{
        //     Debug.LogError("Game Manager not found");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            Debug.Log("Tab press");
            if(hudOpen){
                closeHud();
            }else{
                openHud();
            }
        }
    }

    void openHud(){
        hud.SetActive(true);
        Time.timeScale = 0f;
        hudOpen = true;

        coins = gameManager.GetCoins();

        hudText.SetText("Welcome to your hud \n Coins: {0}", coins);
    }

    void closeHud(){
        hud.SetActive(false);
        Time.timeScale = 1f;

        hudOpen=false;

    }
}
