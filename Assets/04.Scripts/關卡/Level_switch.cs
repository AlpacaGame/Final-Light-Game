using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_switch : MonoBehaviour
{
    public string 標題背景音樂;//1是普通關卡 2是Boos關卡


    // Start is called before the first frame update
    void Start()
    {
        GameManager.遊戲主控.關卡背景音樂切換(標題背景音樂);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
