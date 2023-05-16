using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject UIwin;

    public GameObject UIlose;

    public TextMeshProUGUI txtWin;

    public TextMeshProUGUI txtLose;

    public GameManager gameManager;

    public Image imageTurn;

    

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowWin()
    {
        TurnOffAll();
        UIwin.SetActive(true);
        txtWin.text = gameManager.Gettile + " Win";
        gameManager.gameStaus = GameManager.GameStatus.EndGame;
    }

    public void ShowLose()
    {
        TurnOffAll();
        UIlose.SetActive(true);
        txtLose.text = gameManager.Gettile + " Lose";
        gameManager.gameStaus = GameManager.GameStatus.EndGame;
    }

    public void TurnOffAll()
    {
        UIwin.SetActive(false);
        UIlose.SetActive(false); 
    }

    public void Update()
    {
        ChangeTurn();
    }
    public void ChangeTurn()
    {
        if (gameManager.typeItem == 0)
        {
            imageTurn.sprite = Resources.Load<Sprite>("Prefabs/Blue");

        }
        else
        {
            imageTurn.sprite = Resources.Load<Sprite>("Prefabs/Red");
        }
    }

    
}
