using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public Transform trans;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            Vector3 pos=  Camera.main.ScreenToWorldPoint(mousePos);
            trans.position = pos;
        }
    }

}





