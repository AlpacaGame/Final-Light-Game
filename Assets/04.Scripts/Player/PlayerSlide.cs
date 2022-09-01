using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{

    public bool isSliding = false;

    public Rigidbody2D rigidbody;

    public Animator anim;

    public BoxCollider2D regulorColl;//主體
    public BoxCollider2D SlieColl;//滑行碰撞塊
    public BoxCollider2D CheckWallColl;//偵測有無靠牆方碰撞塊

    public float SlideSpeed = 5f;

    public static bool 滑鏟中;

    public bool 測試滑行開關右, 測試滑行開關左;

    public static bool 防撞牆彈回去 = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        滑鏟中 = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isSliding && PlayerHealth.玩家體力 >= 50)
        {
            prefromSlide();
        }
    }

    private void prefromSlide()
    {
        isSliding = true;
        滑鏟中 = true;

        anim.SetBool("滑鏟中", true);

        regulorColl.enabled = false; //主體 關閉
        SlieColl.enabled = true; //滑行方塊 啟用

        if (玩家控制.direction == 1)
        {
            rigidbody.AddForce(Vector2.right * SlideSpeed);
            玩家控制.滑行測試開關 = true;
            測試滑行開關右 = true;
        }
        else if(玩家控制.direction == -1)
        {
            rigidbody.AddForce(Vector2.left * SlideSpeed);
            玩家控制.滑行測試開關 = true;
            測試滑行開關左 = true;
        }
        //改成用動畫事件控制停止滑鏟
        //Invoke("停止滑鏟", SlideTime);
        //StartCoroutine("stopSlide");
    }
    

    void 抵制滑行()
    {
        if (測試滑行開關左)
        {
            //玩家控制.direction = -1;
            玩家控制.滑行測試開關 = false;
            測試滑行開關左 = false;
        }

        else if (測試滑行開關右)
        {
            //玩家控制.direction = 1;
            玩家控制.滑行測試開關 = false;
            測試滑行開關右 = false;
        }
    }

    void 停止滑鏟()
    {
        anim.SetBool("滑鏟中", false);
        regulorColl.enabled = true;
        SlieColl.enabled = false;
        isSliding = false;
        滑鏟中 = false;
        
        if (玩家控制.direction == -1 && 防撞牆彈回去)
        {
            rigidbody.AddForce(Vector2.right * SlideSpeed / 2);
        }
        else if (玩家控制.direction == 1 && 防撞牆彈回去)
        {
            rigidbody.AddForce(Vector2.left * SlideSpeed / 2);
        }
        
    }
}


