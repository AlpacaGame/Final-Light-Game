using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_on_off : MonoBehaviour
{
    public static bool 門禁卡, 密碼, 手槍;
    public bool 觀看關了門禁卡, 觀看關了密碼, 觀看關了槍;
    public GameObject 卡, 密, 槍,子彈UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        觀看關了門禁卡 = 門禁卡;
        觀看關了密碼 = 密碼;
        觀看關了槍 = 手槍;

        按下任意鍵();

        if (門禁卡)
        {
            卡.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(!門禁卡)
        {
            卡.SetActive(false);
        }

        if(密碼)
        {
            密.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (!密碼)
        {
            密.SetActive(false);
            
        }

        if(手槍)
        {
            槍.SetActive(true);
            子彈UI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (!手槍)
        {
            槍.SetActive(false);
        }
    }

    void 按下任意鍵()
    {

        if (Input.anyKeyDown)
        {
            門禁卡 = false;
            密碼 = false;
            手槍 = false;
            Time.timeScale = 1f;
        }

        /*
        if (Input.anyKeyDown)
        {
            門禁卡 = false;
        }

        if (Input.anyKeyDown)
        {
            密碼 = false;
        }

        if (Input.anyKeyDown)
        {
            手槍 = false;
        }
        */
    }
}
