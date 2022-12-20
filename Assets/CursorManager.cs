using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool destroy = true;
    public bool visible = true;
    void Start()
    {
        if(!destroy && GameManager.遊戲主控.關卡背景音樂 != "標題畫面")
        {
            DontDestroyOnLoad(this);
        }

        if (!visible)
        {
            Cursor.visible = false;
        }
    }
}
