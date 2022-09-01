using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 感光 : MonoBehaviour //裝在感光圖片上
{
    //private Collider2D 感測光範圍;
    //我要利用碰撞關閉實現燈光感知功能
    private SpriteMask 遮罩面板;


    void Start()
    {
        遮罩面板 = GetComponent<SpriteMask>();
        //感測光範圍 = GetComponent<Collider2D>();
        //自訂義參數(自己取名字) = 抓取目標元件<比如說你要抓燈光的元件就找Light/抓框框元件的話找Collider2D>  (); 
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //注意!!配合手電筒的按鍵一起釋放光源 預設按鍵:滑鼠右鍵
        {
            遮罩面板.enabled = !遮罩面板.enabled;
            //感測光範圍.enabled = !感測光範圍.enabled; //開關程式
        }
    }
    //OnTriggerEnter2D 可穿透型的偵測碰撞
    void OnTriggerEnter2D(Collider2D 感測光) //這後面的感測光只是一個自定義參數可隨意更改 記得住就好 這邊設的感測光是要抓到敵人進行移速減緩的程式(暫時以刪除來感知)
    {
        /*
        if (感測光.tag == "敵人") //根据貼標籤給到的那個物件(敵人),進行接下來的指示.
        {
            //Destroy(感測光.gameObject);
        }
        */
    }

}
