using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    private int 敵人生命;
    [SerializeField] private int 敵人生命最大值;
    [SerializeField] protected private int 敵人速度 = 10;

    [SerializeField] protected private bool 殭屍存活;


    public static bool 敵人可攻擊;
    public bool 觀看敵人可攻擊;
    public bool 攻擊時間判定;

    public int 自行設定對玩家要多少傷害;
    public static int 給予攻擊傷害點;

    protected private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        敵人生命 = 敵人生命最大值;
        給予攻擊傷害點 = 自行設定對玩家要多少傷害;

        殭屍存活 = true;

    }

    void Update()
    {
        損血機制();
    }


    void 損血機制()
    {
        if (敵人生命 <= 0)
        {
            敵人生命 = 0;
            殭屍存活 = false;
        }
    }

}