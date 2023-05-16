using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridTileController : MonoBehaviour
{
   

    GameObject obItem;

    public UIController uiController;

    public GameManager gameManger;

    public CameraController camController;

    public TimeController timeController;
    private void Awake()
    {
        camController = FindObjectOfType<CameraController>();
        uiController = FindObjectOfType<UIController>();
        gameManger = FindObjectOfType<GameManager>();
        timeController = FindObjectOfType<TimeController>();
        gameManger.typeItem = 0;
    }

    public Dictionary<Vector3Int, int> matrix = new Dictionary<Vector3Int, int>();
    public void ChangeTypeItem()
    {
        if (gameManger.typeItem == 0)
        {
            gameManger.Gettile = Tile.TileState.Green;
            gameManger.typeItem = 1;
        }
        else
        {
            gameManger.Gettile = Tile.TileState.Red;
            gameManger.typeItem = 0;
        }
    }

    public void ClearAllTile()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        matrix.Clear();
    }

    Vector3 mousePos;
    Vector3 hitPointOnPlane;
    Vector2 endPos;
    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            camController.isMove = true;
            camController.isBack = false;
            camController.isNormal = false;
            Vector2 _mousePos= Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(_mousePos);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f))
            {
                endPos = raycastHit.point;

                camController.endPos = new Vector3(endPos.x, endPos.y, camController.transform.position.z);
            }
        
        }
     
    }
    Vector3Int posInt;
    public void OnClick()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        posInt = PosClickRayCast();

        ClickBoard(posInt);

    }

    public Vector3Int PosClickRayCast()
    {
        mousePos = Input.mousePosition;       

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f))
        {
            hitPointOnPlane = raycastHit.point;
        }
        return Vector3Int.RoundToInt(hitPointOnPlane);
       
    }
    public void ClickBoard(Vector3Int posInt)
    {
        if (!matrix.ContainsKey(new Vector3Int(posInt.x, posInt.y, 0)))
        {
            if (matrix.Count == 0)
            {
                camController.firstPos = new Vector3(hitPointOnPlane.x, hitPointOnPlane.y, camController.transform.position.z);
            }
            camController.isBack = false;
            camController.isMove = false;
            camController.isNormal = true;
            camController.currentPos = new Vector3(hitPointOnPlane.x, hitPointOnPlane.y, camController.transform.position.z);
            timeController.TimeCount = 15;
            ChangeTypeItem();
            SpawnItem(transform, posInt);
            matrix.Add(new Vector3Int(posInt.x, posInt.y, 0), gameManger.typeItem);

            if (CheckWin(posInt.x, posInt.y))
            {
                uiController.ShowWin();
            }
        }

    }
    private void SpawnItem(Transform trans, Vector3Int pos)
    {
        if (gameManger.typeItem == 0)
        {
            GameObject ob = Resources.Load<GameObject>("Prefabs/OTile");
            obItem = Instantiate<GameObject>(ob, trans);
            obItem.GetComponent<Item>().typeItem = Item.TypeItem.Otype;
        }
        else
        {
            GameObject ob = Resources.Load<GameObject>("Prefabs/XTile");
            obItem = Instantiate<GameObject>(ob, trans);
            obItem.GetComponent<Item>().typeItem = Item.TypeItem.Xtype;
        }

        obItem.transform.position = pos;
        obItem.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
    }

    public bool CheckWin(int row, int col)
    {
      
        return (CheckWinVertical(row, col) || CheckWinHorizontal(row, col) || CheckWinRightSlash(row, col) || CheckWinLeftSlash(row, col));

    }
    public int count;
   
    public int countSameType = 6;
    private bool CheckWinHorizontal(int x, int y)
    {
        count = 0;

        for (int i = 0; i < countSameType; i++)
        {
            
            if (!matrix.ContainsKey(new Vector3Int(x, y + i, 0))) break;
            if (matrix[new Vector3Int( x, y + i,0)] == gameManger.typeItem)
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
            if (!matrix.ContainsKey(new Vector3Int(x, y - i, 0))) break;
            if (matrix[new Vector3Int(x, y - i,0)] == gameManger.typeItem)
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
            if (!matrix.ContainsKey(new Vector3Int(x + i, y, 0))) break;
            if (matrix[new Vector3Int( x + i, y,0)] == gameManger.typeItem)
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
            if (!matrix.ContainsKey(new Vector3Int(x - i, y, 0))) break;
            if (matrix[new Vector3Int( x - i, y,0)] == gameManger.typeItem)
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

        for (int i = 0; i < countSameType; i++)
        {
            if (!matrix.ContainsKey(new Vector3Int(x + i, y + i, 0))) break;
            if ( matrix[ new Vector3Int(x + i, y + i, 0)] == gameManger.typeItem)
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
            if (!matrix.ContainsKey(new Vector3Int(x - i, y - i, 0))) break;
            if (matrix[new Vector3Int( x - i, y - i,0)] == gameManger.typeItem)
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
            if(!matrix.ContainsKey(new Vector3Int(x + i, y - i, 0))) break;
            if (matrix[new Vector3Int( x + i, y - i,0)] == gameManger.typeItem)
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
            if (!matrix.ContainsKey( new Vector3Int(x - i, y + i, 0))) break;
            if ( matrix[new Vector3Int( x - i, y + i,0)] == gameManger.typeItem)
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
    
    public void BackToFirst()
    {
        
    }
}
