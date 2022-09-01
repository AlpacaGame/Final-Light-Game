using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 手電筒 : MonoBehaviour //裝在燈光上以便來進行燈光開關調節
{
    private Light 手電筒的光;

    public AudioClip 開音效;
    public AudioClip 關音效;
    //private bool 手電開啟;

    void Start()
    {
        手電筒的光 = GetComponent<Light>();
        //自訂義參數(自己取名字) = 抓取目標元件<比如說你要抓燈光的元件就找Light/抓框框元件的話找Collider2D>  (); 
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //注意!!配合(隱形)感測的按鍵一起釋放光源 預設按鍵:F
        {
            //GetComponent<AudioSource>().PlayOneShot(開音效);
            手電筒的光.enabled = !手電筒的光.enabled; //開關程式
            
        }

        if(Input.GetMouseButtonDown(1) && !手電筒的光.enabled)
        {
            GetComponent<AudioSource>().PlayOneShot(開音效);
        }
        else if(Input.GetMouseButtonDown(1) && 手電筒的光.enabled)
        {
            GetComponent<AudioSource>().PlayOneShot(關音效);
        }
    }

}