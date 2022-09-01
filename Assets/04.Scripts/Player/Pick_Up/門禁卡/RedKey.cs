using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : MonoBehaviour
{

    public bool 可以獲取鑰匙;
    public static bool 鑰匙拾取過 = false;

    // Start is called before the first frame update
    void Start()
    {
        if (鑰匙拾取過)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && 可以獲取鑰匙)
        {
            Destroy(gameObject);
            //玩家控制.紅鑰匙 += 1;
            鑰匙拾取過 = true;
            Pick_Up.PickAccessCard = true;
        }
    }

    void OnTriggerEnter2D(Collider2D Key)
    {
        if (Key.gameObject.tag == "Player")
        {
            可以獲取鑰匙 = true;
        }
    }

    void OnTriggerExit2D(Collider2D Key)
    {
        if (Key.gameObject.tag == "Player")
        {
            可以獲取鑰匙 = false;
        }
    }
}
