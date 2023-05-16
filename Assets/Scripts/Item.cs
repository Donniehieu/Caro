using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Color color;

    public GridTileController gridTileController;

    public GameManager gameManger;

    public GameObject obItem;
    public enum TypeItem
    {
        Otype,
        Xtype
    }
    public TypeItem typeItem;

    private void OnValidate()
    {
        gridTileController = FindObjectOfType<GridTileController>();
        gameManger = FindObjectOfType<GameManager>();
    }
  
    public void SetColor(Color _color)
    {
        color = _color;
    }
 
   
  
    public void InstanceItem()
    {
        if (gameManger.typeItem == 0)
        {   

            typeItem = TypeItem.Otype;
        }
        else
        {
            typeItem = TypeItem.Xtype;
        }
    }

    
   


}
