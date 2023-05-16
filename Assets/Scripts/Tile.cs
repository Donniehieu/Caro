using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileController tileController;

    public int row, column;

    public GridLevel gridLevel;

    public TileState tileState;

    public GameManager gameManager;

    public UIController uiController;
    public enum TileState
    {
        isEmpty,
        Green,
        Red
    }
    public SpriteRenderer spriteTile;

    public bool isClicked = false;



    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
         
        tileController = FindObjectOfType<TileController>();

        gridLevel = FindObjectOfType<GridLevel>();

        uiController = FindObjectOfType<UIController>();

        spriteTile = GetComponent<SpriteRenderer>();

        tileState = TileState.isEmpty;
    }

    private void OnMouseDown()
    {
        if (isClicked == true) return;
        isClicked = true;

        tileController.countClick++;

        GetTileSprite(gridLevel.currentTurn);

        GetComponent<SpriteRenderer>().sprite = spriteTile.sprite;

        transform.localScale = new Vector3(0.3f, 0.3f, 0);

        if (gridLevel.CheckWin(row, column))
        {
            gameManager.Gettile = this.tileState;
            uiController.ShowWin();
        }


    }
    private void GetTileSprite(string Str)
    {
        if (Str == "x")
        {
            tileState = TileState.Red;
            spriteTile = tileController.spriteTiles[1];
            gridLevel.currentTurn = "o";
        }
        else
        {
            tileState = TileState.Green;
            spriteTile = tileController.spriteTiles[0];
            gridLevel.currentTurn = "x";
        }

    }



}
