using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 endPos;

    public Vector3 currentPos;

    public Vector3 firstPos;

    public bool isMove;

    public bool isBack;

    public bool isNormal;

    
    private void Start()
    {
        endPos = new Vector3(0, 0, -23);
        currentPos = new Vector3(0, 0, -23);
        firstPos = new Vector3(0, 0, -23);
        
        isMove = false;
        isBack = false;
    }
    private void MoveCamera()
    {
        
            if ( Input.touchCount > 0&& Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 deltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(deltaPosition.x * 0.01f, deltaPosition.y * 0.01f, -23);

                transform.position = new Vector3(

                    Mathf.Clamp(transform.position.x, -44f, 44f),
                    Mathf.Clamp(transform.position.y, -44f, 44f),
                    Mathf.Clamp(transform.position.z, -23, -23));
            }
        
        
        
    }

    public void MoveCamera(Vector3 _targetPos)
    {

       transform.position= Vector3.MoveTowards(transform.position, _targetPos, Time.deltaTime * 10);
    }
    public void Update()
    {  
        //if(isNormal==true)
        //MoveCamera(currentPos);

        if (isMove == true)
        {
            MoveCamera(endPos);
        }
        if (isBack == true)
        {
            MoveCamera(firstPos);
        }
        
    }

}
