using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GridTileController
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }
}
