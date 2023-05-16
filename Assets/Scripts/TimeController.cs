using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeController : MonoBehaviour
{
    private float timeCount;

    public TextMeshProUGUI txtTimeCount;

    public GameManager gameManage;

    public bool CR_running;

    private void OnValidate()
    {
        gameManage = FindObjectOfType<GameManager>();
    }
    public float TimeCount
    {
        get { return timeCount; }
        set { timeCount = value;
            txtTimeCount.text = timeCount.ToString();
        }
    }

    public IEnumerator CountDownTime()
    {
        
        while (TimeCount > 0 && gameManage.gameStaus==GameManager.GameStatus.Playing)
        {
            CR_running = true;
            yield return new WaitForSeconds(1);
            TimeCount--;
            if (TimeCount <= 0)
            {
                gameManage.SetCurrentLose();
            }
            CR_running = false;
        }
    }
}
