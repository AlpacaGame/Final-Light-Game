using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Player : MonoBehaviour
{
    [Header("玩家移動")]
    public float energy = 100;//玩家體力
    public float breatheEnergy = 50;//喘氣體力值
    public float inputX = 0;//左右移動值
    public float walkSpeed = 1.4f;//走路速度
    public float runSpeed = 10;//跑步速度
    public float runEnergyDecrease = 0.5f;//跑步體力消耗
    public float walkEnergyIncrease = 0f;//走路體力增加
    public float idleEnergyIncrease = 1f;//待機體力增加
    public bool slide = false;
    public bool breath = false;
    public float playerSpeed = 0;
    public float playerMaxSpeed = 5;

    [Header("生命值")]
    public int health = 100;

    [Space(5)]
    [Header("Ragdoll切換需要的物件")]
    [SerializeField] private Animator _anim;
    [SerializeField] private List<Collider2D> _colliders;
    [SerializeField] private List<HingeJoint2D> _joints;
    [SerializeField] private List<Rigidbody2D> _rbs;
    [SerializeField] private List<LimbSolver2D> _solvers;

    [Header("掛載元件")]
    private Rigidbody2D rg;
    private Animator anim;

    void Start()
    {
        ToggleRagdoll(false);//開始時關閉布娃娃系統

        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    //玩家移動
    public void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");

        if(health > 0)
        {
            if (inputX != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) && energy > 50)//按下Shift鍵 & 體力不為0
                {
                    Run();
                    anim.SetBool("isRun", true);
                }
                else if (Input.GetKey(KeyCode.LeftShift) && energy > 0)//按下Shift鍵 & 體力不為0
                {
                    Run();
                    anim.SetBool("isFastWalk", true);
                }
                else
                {
                    Walk();
                    anim.SetBool("isWalk", true);
                    anim.SetBool("isFastWalk", false);
                }
            }
            else
            {
                Idle();
                anim.SetBool("isWalk", false);
                anim.SetBool("isRun", false);
            }
        }
    }

    //待機
    public void Idle()
    {
        //anim.Play("Idle");
        energy += idleEnergyIncrease;//能量增加
    }

    //走路
    public void Walk()
    {
        rg.velocity = new Vector2(inputX * walkSpeed, rg.velocity.y);
        //anim.Play("Walk");
        energy += walkEnergyIncrease;//能量增加
    }

    //跑步
    public void Run()
    {
        rg.velocity = new Vector2(inputX * runSpeed, rg.velocity.y);
        //anim.Play("Run");
        energy -= runEnergyDecrease;//能量消耗

        //喘氣聲
        if (energy <= breatheEnergy && !breath)
        {
            breath = true;
            SoundManager.instance.PantSource();
            Invoke("BreatheTime", 5);
        }
    }

    //喘氣聲間隔
    public void BreatheTime()
    {
        breath = false;
    }

    //Ragdoll切換
    public void ToggleRagdoll(bool ragdollOn)
    {
        _anim.enabled = !ragdollOn;

        foreach (var col in _colliders)
        {
            col.enabled = ragdollOn;
        }

        foreach (var joint in _joints)
        {
            joint.enabled = ragdollOn;
        }

        foreach (var rb in _rbs)
        {
            rb.simulated = ragdollOn;
        }

        foreach (var solver in _solvers)
        {
            solver.weight = ragdollOn ? 0 : 1;
        }
    }

    //接收傷害
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    //死亡
    public void Die()
    {
        ToggleRagdoll(true);
    }
}
