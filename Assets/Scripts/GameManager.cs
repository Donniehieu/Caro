using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
   
    public Tile.TileState Gettile;

    public UIController uiController;

    public TimeController timeController;

    public GridTileController gridTileController;

    public CameraController cameraController;   

    public int typeItem;

    public GameStatus gameStaus;
    public enum GameStatus
    {
        Playing, 
        EndGame
    }

    private void Awake()
    {
      
        uiController = FindObjectOfType<UIController>();
        timeController = FindObjectOfType<TimeController>();
        gridTileController = FindObjectOfType<GridTileController>();
        cameraController = FindObjectOfType<CameraController>();
        StartGame();
    }
  
    public void SetCurrentLose()
    {
        if(Gettile == Tile.TileState.isEmpty)
        {
            Gettile = Tile.TileState.Green;
        }
        else if(Gettile == Tile.TileState.Green)
        {
            Gettile = Tile.TileState.Red;
        }
        uiController.ShowLose();
    }

    public void Replay()
    {
        StartGame();
    }

    private void StartGame()
    {
        gridTileController.ClearAllTile();
        gameStaus = GameStatus.Playing;
        timeController.TimeCount = 15;
        StartCoroutine(timeController.CountDownTime());
        uiController.TurnOffAll();
    }
    public void ClickBacktoFirstPos()
    { 
        cameraController.isMove = false;
        cameraController.isNormal = false;
        cameraController.isBack = true;
    }
}
