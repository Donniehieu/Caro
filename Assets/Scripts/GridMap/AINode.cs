using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINode : MonoBehaviour
{

    public List<Vector3Int> containerList = new List<Vector3Int>();

    public GameObject ob;

    public GridTileController gridtileController;
    public void Start()
    {
        GetContainerList(Vector3Int.one);
        gridtileController = FindObjectOfType<GridTileController>();
    }

    public List<Vector3Int> GetContainerList(Vector3Int pos)
    {
       for(int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                containerList.Add(pos + new Vector3Int(i, j, 0));                
            }
        }
        return containerList;
    }

    void SpawnObject()
    {
        for (int i = 0; i < containerList.Count; i++)
        {
            GameObject _ob = Instantiate(ob, gridtileController.transform);
            _ob.transform.position = containerList[i];
        }
       
        
    }
}
