using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zombie : Enemy
{
    public int 敵人生命最大值 = 100;
    public int 敵人生命 = 0;
    public int 觀看敵人生命 = 0;
    private Animator anim;
    public bool 殭屍存活;

    public Transform 範圍左, 範圍右, 範圍中, 敵人偵測到玩家;
    public int 敵人速度 = 10;
    private float direction;//殭屍面向

    public int 機率假死;
    public bool 機率事件 = true;

    public static bool 敵人可攻擊;
    public bool 觀看敵人可攻擊;
    public bool 攻擊時間判定;

    public int 自行設定對玩家要多少傷害;
    public static int 給予攻擊傷害點;

    public static bool 新手教學用 = false;
    public float 調整教學時間 = 5f;
    public bool 新手教學死亡 = false;

    void Start()
    {
        
        給予攻擊傷害點 = 自行設定對玩家要多少傷害;
        anim = GetComponent<Animator>();
        殭屍存活 = true;

        機率假死 = Random.Range(0, 5);


        //讓左右翻轉程式知道一開始是面向哪
        if (範圍左.position.x < 範圍右.position.x)//殭屍向左
        {
            direction = 0.5f;//向左
        }

        if (範圍左.position.x > 範圍右.position.x)//殭屍向右
        {
            direction = -0.5f;//向左
        }
    }

    void Update()
    {
        敵人攻擊();
        損血機制();
        if (新手教學用)
        {
            新手教學();
            機率假死 = 0;
        }
        觀看敵人生命 = 敵人生命;

        敵人偵測到玩家 = GameObject.Find("玩家偵測點").GetComponent<Transform>();

        if (新手教學死亡)
        {
            //anim.SetBool("新手殭屍", true);
            anim.Play("教學結束");
            Active_Object.開關 = false;
        }

    }

    void 新手教學()
    {
        anim.Play("教學");
        Invoke("打頭", 調整教學時間);
        新手教學用 = false;
        Active_Object.開關 = true;

    }

    void 打頭()
    {
        if (敵人生命 > 0)
        {
            anim.Play("試著打頭");
        }
    }

    void 敵人攻擊()
    {
        觀看敵人可攻擊 = 敵人可攻擊;
        if (敵人可攻擊)
        {
            攻擊時間判定 = true;
            敵人速度 = 0;
            anim.SetBool("殭屍攻擊", true);
        }

        else if (!敵人可攻擊)
        {
            //Invoke("攻擊結束", 5f);
            //敵人速度 = 10;
            //anim.SetBool("殭屍攻擊", false);
        }
    }

    void 攻擊結束()
    {
        敵人速度 = 10;
        anim.SetBool("殭屍攻擊", false);
        攻擊時間判定 = false;
    }

    void 損血機制()
    {
        敵人生命 = health;
        if (敵人生命 <= 0)
        {
            敵人生命 = 0;
            殭屍存活 = false;
            anim.SetBool("待機", false);
            anim.SetBool("追逐", false);
            anim.SetBool("殭屍死亡", true);
            新手教學死亡 = true;
        }

        else if (敵人生命 <= 50 && 機率假死 >= 3 && 機率事件)
        {
            殭屍存活 = false;
            機率事件 = false;
            anim.SetBool("待機", false);
            anim.SetBool("追逐", false);
            anim.SetBool("殭屍死亡", true);
            Invoke("假死後起來", 4f);
        }


    }

    void 假死後起來()
    {
        anim.SetBool("殭屍死亡", false);
        anim.SetBool("待機", true);
        殭屍存活 = true;
    }

    void FixedUpdate()
    {
        if (殭屍存活)//如果殭屍活著
        {
            anim.SetBool("待機", true);
            anim.SetBool("追逐", false);

            //左右翻轉
            if (direction > 0)//向左
            {
                if (範圍中.position.x + 0.1f < 敵人偵測到玩家.position.x && 範圍右.position.x > 敵人偵測到玩家.position.x)//玩家在殭屍右側
                {
                    direction = -0.5f;//往右
                    transform.localScale = new Vector3(direction, 0.5f, 0.5f);
                }
            }

            if (direction < 0)//向右
            {
                if (範圍中.position.x > 敵人偵測到玩家.position.x && 範圍右.position.x < 敵人偵測到玩家.position.x)//玩家在殭屍左側
                {
                    direction = 0.5f;//往左
                    transform.localScale = new Vector3(direction, 0.5f, 0.5f);
                }
            }

            //移動
            if (範圍中.position.x > 敵人偵測到玩家.position.x && 範圍左.position.x < 敵人偵測到玩家.position.x && !攻擊時間判定)//玩家在殭屍左側
            {
                transform.Translate(Vector2.left * 敵人速度 * Time.deltaTime * 0.2f);
                anim.SetBool("待機", false);
                anim.SetBool("追逐", true);
            }

            if (範圍中.position.x < 敵人偵測到玩家.position.x && 範圍左.position.x > 敵人偵測到玩家.position.x && !攻擊時間判定)//玩家在殭屍右側
            {
                transform.Translate(Vector2.right * 敵人速度 * Time.deltaTime * 0.2f);
                anim.SetBool("待機", false);
                anim.SetBool("追逐", true);
            }
        }
    }
}
