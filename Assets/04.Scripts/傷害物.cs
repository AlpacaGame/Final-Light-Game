using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 傷害物 : MonoBehaviour
{
    //public PlayerHealth 小白;
    public bool 受損 = false;
    void OnCollisionEnter2D(Collision2D 角色)
    {
        if (角色.gameObject.tag == "Player")
        {
            受損 = true;
        }
        else
        {
            受損 = false;
        }
    }
    void OnCollisionExit2D(Collision2D 角色)
    {
        if (角色.gameObject.tag == "Player")
        {
            受損 = false;
        }
    }
}