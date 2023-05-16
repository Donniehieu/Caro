using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLevel : MonoBehaviour
{
    public string[,] tileGrid;

    public GameObject tilePrefab;

    public int boadSize;

    public string currentTurn = "x";

    public Tile.TileState tileState;
    private void Start()
    {
        tileGrid = new string[boadSize, boadSize];
        InstanceGridBoard();
    }


    private void InstanceGridBoard()
    {
        for (int i = 1; i < boadSize; i++)
        {
            for (int j = 1; j < boadSize; j++)
            {
                GameObject tileOb = Instantiate(tilePrefab, transform);

                tileOb.transform.localPosition = new Vector3(j, i, 0);

                tileOb.GetComponent<Tile>().row = i;
                tileOb.GetComponent<Tile>().column = j;
                tileGrid[i, j] = "";
            }
        }
    }

    public int count;
    public bool CheckWin(int row, int col)
    {

        tileGrid[row, col] = currentTurn;
        return (CheckWinVertical(row, col) || CheckWinHorizontal(row, col) || CheckWinRightSlash(row, col) || CheckWinLeftSlash(row, col));


    }

    int countSameType = 4;
    private bool CheckWinHorizontal(int x, int y)
    {
        count = 0;
       
        for (int i =0 ; i < countSameType; i++)
        {
            if (y + i < boadSize && tileGrid[x, y+i] == currentTurn )
            {
                count++;
            }
            else
            {
                break;
            }

        }
        for (int i = 0; i < countSameType; i++)
        {
            if (y>=i&& tileGrid[x, y-i] == currentTurn)
            {

                count++;
            }
            else
            {
                break;
            }

        }
        return count >= countSameType;
        
    }

    private bool CheckWinVertical(int x, int y)
    {
        count = 0;
     
        for (int i = 0; i < countSameType; i++)
        {
            if (x+i<boadSize&& tileGrid[x+i, y] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }

        }
        for (int i = 0; i< countSameType; i++)
        {
            if (x>=i&& tileGrid[x-i, y] == currentTurn)
            {

                count++;
            }
            else
            {
                break;
            }

        }
        return count >= countSameType;
    }
    private bool CheckWinRightSlash(int x, int y)
    {
        count = 0;
     
        for (int i =0;i < countSameType; i++)
        {
           
            if (x+i<boadSize && y+i< boadSize&& tileGrid[x+i, y+i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        for (int i = 0; i < countSameType; i++)
        {
                if (x>=i && y>=i && tileGrid[x-i, y-i] == currentTurn)
                {

                    count++;
                }
                else
                {
                    break;
                }
        }

        return count >= countSameType;

    }

    private bool CheckWinLeftSlash(int x, int y)
    {
        count = 0;
   
        for (int i = 0; i < countSameType; i++)
        {

            if (x+i<boadSize&& y>=i && tileGrid[x + i, y -i] == currentTurn)
            {
                count++;
            }
            else
            {
                break;
            }
        }

        for (int i = 0; i < countSameType; i++)
        {
            if (y+i<boadSize&& x >= i && tileGrid[x - i, y + i] == currentTurn)
            {

                count++;
            }
            else
            {
                break;
            }
        }

        return count >= countSameType;
    }


}
