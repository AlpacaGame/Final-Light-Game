using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGunsprite : MonoBehaviour
{
    public Sprite 手持手槍, 手持步槍; // 新的Sprite圖片

    private SpriteRenderer spriteRenderer; // SpriteRenderer元件的參考


    // Start is called before the first frame update
    void Start()
    {
        // 取得當前遊戲物件上的SpriteRenderer元件
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 檢查是否成功取得SpriteRenderer元件
        /*
        if (spriteRenderer != null)
        {

        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Gun_fire.切換武器編號 == 0 && GameManager.擁有手槍)
        {
            spriteRenderer.sprite = 手持手槍;
        }

        if (Gun_fire.切換武器編號 == 1 && GameManager.擁有步槍)
        {
            spriteRenderer.sprite = 手持步槍;
        }
    }

}
