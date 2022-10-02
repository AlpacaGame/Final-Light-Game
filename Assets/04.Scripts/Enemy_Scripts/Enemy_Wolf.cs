using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Wolf : MonoBehaviour
{
    public int 敵人生命最大值 = 100;
    public int 敵人生命 = 0;
    public int 觀看敵人生命 = 0;
    private Animator anim;
    public bool 殭屍存活;

    public Transform 範圍左, 範圍右, 範圍中, 敵人偵測到玩家;
    public int 敵人速度 = 10;
    public float direction;//殭屍面向

    public static bool 敵人可攻擊;
    public bool 觀看敵人可攻擊;
    public bool 攻擊時間判定;

    public int 自行設定對玩家要多少傷害;
    public static int 給予攻擊傷害點;

    public bool 切換方向;

    void Start()
    {
        敵人生命 = 敵人生命最大值;
        給予攻擊傷害點 = 自行設定對玩家要多少傷害;
        anim = GetComponent<Animator>();
        殭屍存活 = true;


        //讓左右翻轉程式知道一開始是面向哪
        
        if (範圍左.position.x < 範圍右.position.x)//殭屍向左
        {
            direction = -0.15f;//向左
        }

        if (範圍左.position.x > 範圍右.position.x)//殭屍向右
        {
            direction = 0.15f;//向左
        }
        
    }

    void Update()
    {
        敵人攻擊();
        損血機制();
        
        觀看敵人生命 = 敵人生命;

        敵人偵測到玩家 = GameObject.Find("玩家偵測點").GetComponent<Transform>();
        
        /*
        if(Input.GetKeyDown(KeyCode.M))
        {
            
            切換方向 = !切換方向;
        }
        
        if(切換方向)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            //transform.Rotate(0, 0, 0);
            //transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }
        else if(!切換方向)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            //transform.rotate = new Vector3(0, 10, 0);
            //transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
        }
        */
    }

    void 敵人攻擊()
    {
        觀看敵人可攻擊 = 敵人可攻擊;
        if (敵人可攻擊)
        {
            //攻擊時間判定 = true;
            敵人速度 = 0;
            //anim.SetBool("殭屍攻擊", true);
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
        //anim.SetBool("殭屍攻擊", false);
        //攻擊時間判定 = false;
    }

    void 損血機制()
    {

        if (敵人生命 <= 0)
        {
            敵人生命 = 0;
            殭屍存活 = false;
            anim.SetBool("待機", false);
            anim.SetBool("追逐", false);
            anim.SetBool("殭屍死亡", true);
        }

    }

    void FixedUpdate()
    {
        if (殭屍存活)//如果殭屍活著
        {
            anim.SetBool("待機", true);
            anim.SetBool("追逐", false);
            //transform.Translate(Vector2.right * 敵人速度 * Time.deltaTime * 0.2f);
            //transform.Translate(Vector2.left * 敵人速度 * Time.deltaTime * 0.2f);

            //左右翻轉
            
            if (direction > 0)//向左
            {
                if (範圍中.position.x + 0.1f < 敵人偵測到玩家.position.x && 範圍右.position.x > 敵人偵測到玩家.position.x)//玩家在殭屍右側
                {
                    direction = 0.15f;//往右
                    //transform.localScale = new Vector3(direction, 0.15f, 0.15f);
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
            }

            if (direction < 0)//向右
            {
                if (範圍中.position.x > 敵人偵測到玩家.position.x && 範圍右.position.x < 敵人偵測到玩家.position.x)//玩家在殭屍左側
                {
                    direction = -0.15f;//往左
                    //transform.localScale = new Vector3(direction, 0.15f, 0.15f);
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                }
            }
            
            
            //移動
            if (範圍中.position.x > 敵人偵測到玩家.position.x && 範圍左.position.x < 敵人偵測到玩家.position.x && !攻擊時間判定)//玩家在殭屍左側
            {
                transform.Translate(Vector2.left * 敵人速度 * Time.deltaTime * 0.2f);
                anim.SetBool("待機", false);
                anim.SetBool("追逐", true);
            }
            
            if (範圍中.position.x < 敵人偵測到玩家.position.x && 範圍右.position.x > 敵人偵測到玩家.position.x && !攻擊時間判定)//玩家在殭屍右側
            {
                transform.Translate(Vector2.right * 敵人速度 * Time.deltaTime * 0.2f);
                anim.SetBool("待機", false);
                anim.SetBool("追逐", true);
            }
            
        }
    }
}