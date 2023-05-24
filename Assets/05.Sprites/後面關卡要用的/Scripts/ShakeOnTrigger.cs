using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnTrigger : MonoBehaviour
{
    //private ShakeEffect shakeEffect; // 震動效果腳本的參考
    private bool hasTriggered = false; // 是否已觸發震動的標誌位

    private void Start()
    {
        //shakeEffect = GetComponent<ShakeEffect>(); // 取得震動效果腳本的參考
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player")) // 檢查是否已觸發且碰撞物件是否是玩家
        {
            //shakeEffect.Shake(1, 0.5f, 0.1f); // 調用震動程式，參數可根據需求自行調整
            ScreenShake.instance.StartShake(0.5f, 0.2f);
            hasTriggered = true; // 將觸發標誌位設為已觸發
        }
    }
}
