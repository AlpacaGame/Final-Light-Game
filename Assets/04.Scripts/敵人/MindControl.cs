using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControl : MonoBehaviour
{
    public bool 被打到 = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (被打到)
        {
            玩家控制.可以心靈控制了 = true;
        }
    }

    void OnTriggerEnter2D(Collider2D Mindcontrol)
    {
        if (Mindcontrol.CompareTag("Bullet"))
        {
            被打到 = true;
            //給予攝影機.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D Mindcontrol)
    {
        if (Mindcontrol.CompareTag("Bullet"))
        {
            被打到 = false;
            //給予攝影機.SetActive(true);
        }
    }
    /*
    void OnTriggerExit2D(Collider2D Mindcontrol)
    {
        if (Mindcontrol.gameObject.tag == "Mindcontrol_Ammo")
        {
            玩家控制.可以心靈控制了 = true;
            //給予攝影機.SetActive(false);
        }
    }
    */
}
