using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 玩家移動: MonoBehaviour
{
    public static float speed = 3f;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        /*
        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(x, 0, 0);
        */
  
        if (Input.GetKey(KeyCode.A))//左右移動
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}

