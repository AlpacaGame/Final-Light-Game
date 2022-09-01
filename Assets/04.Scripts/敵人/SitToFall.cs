using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitToFall : MonoBehaviour
{
    //public Transform Left, Player;
    private Animator anim;
    public static bool 動畫開 = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        執行動畫();
        
    }
    
    void 執行動畫()
    {
        if(動畫開)
        {
            anim.Play("fallend");
        }
    }
    void 結束掉頭()
    {
        動畫開 = true;
    }

    void OnTriggerEnter2D(Collider2D Fall)
    {
        if (Fall.gameObject.tag == "Player")
        {
            anim.SetBool("Fall", true);
            Invoke("結束掉頭", 1.2f);
        }
    }
}
