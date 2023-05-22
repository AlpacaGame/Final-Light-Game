using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    private Transform targetPosition; // 目標位置的 Transform 組件

    private void Update()
    {
        // 持續偵測 "玩家重生點" 的存在並抓取
        if (targetPosition == null)
        {
            GameObject respawnPoint = GameObject.Find("玩家重生點");
            if (respawnPoint != null)
            {
                targetPosition = respawnPoint.transform;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Teleport();
        }
    }

    public void Teleport()
    {
        // 檢查目標位置是否存在
        if (targetPosition != null)
        {
            // 將物體的位置設置為目標位置的位置
            transform.position = targetPosition.position;
        }
        else
        {
            Debug.LogWarning("目標位置未設定！");
        }
    }
}
