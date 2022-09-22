using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public bool 撿拾道具 = false;

    public bool 門禁卡, 密碼鎖密碼, 手槍 =false;


    //public static bool 鑰匙拾取過 = false;

    // Start is called before the first frame update



    void Start()
    {
        /*
        if (鑰匙拾取過)
        {
            Destroy(gameObject);
            //另外寫
        }
        */
    }

    // Update is called once per frame
    void LateUpdate()
    {
        撿拾哪一種道具();
        撿過就刪除();
        
        /*
         if (Input.GetKey(KeyCode.E) && 撿拾道具)
        {
            Destroy(gameObject);
            //鑰匙拾取過 = true;
            Pick_Up.PickAccessCard = true;
        }
         */
    }

    void 撿拾哪一種道具()
    {
        if (Input.GetKey(KeyCode.E) && 撿拾道具 && 門禁卡)
        {
            Destroy(gameObject);
            GameManager.擁有門禁卡 = true;
            SoundManager.instance.PickUpSource();

            /*
            Block targetBlock = talkFlowchart.FindBlock(onTriggerEnter2D);
            talkFlowchart.ExecuteBlock(targetBlock);
        */
        }

        else if (Input.GetKey(KeyCode.E) && 撿拾道具 && 密碼鎖密碼)
        {
            Destroy(gameObject);
            GameManager.擁有密碼鎖密碼 = true;
            SoundManager.instance.PickUpSource();
        }

        else if(Input.GetKey(KeyCode.E) && 撿拾道具 && 手槍)
        {
            Destroy(gameObject);
            GameManager.擁有手槍 = true;
            Enemy_Zombie.新手教學用 = true;
            SoundManager.instance.PickUpSource();
        }
    }
    void 撿過就刪除()
    {
        if (門禁卡 && GameManager.擁有門禁卡)
        {
            Destroy(gameObject);
        }

        else if(密碼鎖密碼 && GameManager.擁有密碼鎖密碼)
        {
            Destroy(gameObject);
        }
        
        else if (手槍 && GameManager.擁有手槍)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D Key)
    {
        if (Key.gameObject.tag == "Player")
        {
            撿拾道具 = true;
        }
    }

    void OnTriggerExit2D(Collider2D Key)
    {
        if (Key.gameObject.tag == "Player")
        {
            撿拾道具 = false;
        }
    }
}
