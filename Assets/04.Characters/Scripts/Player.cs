using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Player : MonoBehaviour
{
    [Header("玩家面向")]
    public Camera Orthographic;//平行攝影機
    public static int direction = 1;//左右面向(向右=1，向左=-1)

    [Header("玩家體力值")]
    public float energy = 100;//玩家體力
    public float breatheEnergy = 50;//喘氣體力值
    public float runEnergyDecrease = 5f;//跑步體力消耗
    public float slideEnergyDecrease = 50;//滑行體力消耗
    public float walkEnergyIncrease = 0f;//走路體力增加
    public float idleEnergyIncrease = 1f;//待機體力增加

    [Header("玩家移動")]
    public float inputX = 0;//左右移動值
    public float walkSpeed = 1.4f;//走路速度
    public float runSpeed = 10;//跑步速度
    public float slideSpeed = 20;//滑行速度

    [Header("玩家動畫")]
    public bool sliding = false;//滑行中
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
        PlayerMove();
    }

    private void FixedUpdate()
    {
        
        PlayerDirection();
    }

    //玩家面向 偵測鼠標調整角色左右面向
    public void PlayerDirection()
    {
        Vector3 difference = Orthographic.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (rotationZ < -90 || rotationZ > 90)
        {
            direction = -1;
            transform.localScale = new Vector3(direction, 1, 1);
        }

        else if (rotationZ > -90 || rotationZ < 90)
        {
            direction = 1;
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    //玩家移動
    public void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");

        if(health > 0)
        {
            if(Input.GetKeyDown(KeyCode.C) && energy > slideEnergyDecrease && !sliding)
            {
                Slide();
            }
            else if (inputX != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) && energy > runEnergyDecrease)
                {
                    Run();
                }
                else
                {
                    Walk();
                }
            }
            else
            {
                Idle();
            }
        }

        if(energy >= 100)
        {
            energy = 100;
        }
    }

    //待機
    public void Idle()
    {
        energy += idleEnergyIncrease;//能量增加
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", false);
    }

    //走路
    public void Walk()
    {
        rg.velocity = new Vector2(inputX * walkSpeed, rg.velocity.y);
        energy += walkEnergyIncrease;//能量增加

        anim.SetBool("isWalking", true);
        anim.SetBool("isRunning", false);
    }

    //跑步
    public void Run()
    {
        rg.velocity = new Vector2(inputX * runSpeed, rg.velocity.y);
        //anim.Play("Run");
        energy -= runEnergyDecrease;//能量消耗

        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", true);

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

    //滑行
    public void Slide()
    {
        sliding = true;
        anim.SetBool("isSliding", true);
        energy -= slideEnergyDecrease;
        rg.velocity = new Vector2(direction * slideSpeed, rg.velocity.y);
    }

    //滑行結束
    public void SlideOver()
    {
        sliding = false;
        anim.SetBool("isSliding", false);
        rg.velocity = new Vector2(0, rg.velocity.y);
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
