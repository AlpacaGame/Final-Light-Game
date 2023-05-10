using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Player : MonoBehaviour
{
    public static Player 不可重複;//這是我新增的 防銷毀
    public static bool Story_notmove;//劇情不可亂動

    [Header("掛載元件")]
    private Rigidbody2D rg;
    private Animator anim;


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

    [Header("體力值無限模式")]
    public bool energyUnlimited = false;

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
    public bool CanSlideAgain = true;//滑行間隔使用
    public float SlideAgainTime = 3;//滑行間隔時間


    [Header("滑行關閉碰撞塊")]
    public Collider2D collWalk;
    public Collider2D collSlide;

    [Header("生命值")]
    public static int health = 100;


    [Space(5)]
    [Header("Ragdoll切換需要的物件")]
    [SerializeField] private Animator _anim;
    [SerializeField] private List<Collider2D> _colliders;
    [SerializeField] private List<HingeJoint2D> _joints;
    [SerializeField] private List<Rigidbody2D> _rbs;
    [SerializeField] private List<LimbSolver2D> _solvers;

    [Header("切換手臂")]
    public bool switchingHand = false;//開啟切換手臂
    public GameObject handF, handB;//未持槍手
    public GameObject pistolHand;//持槍手

    [Header("手電筒")]
    public bool flashlightSwitch = true;//手電筒開關
    public GameObject flashlight, flashlightMask;//手電筒, 手電筒遮罩

    [Header("手槍準星跟隨鼠標")]
    public GameObject pistolTarget;

    void Start()
    {
        ToggleRagdoll(false);//開始時關閉布娃娃系統

        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (不可重複 != null)//這是我新增的 防銷毀
        {
            Destroy(gameObject);
            return;
        }
        不可重複 = this;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (GameManager.遊戲主控.關閉主角) //標題消除玩家
        {
            標題消除玩家();
        }
        if (Story_notmove)
        {
            Idle();
        }
        if (!Story_notmove)
        {
            PlayerMove();
            SwitchingHand();
        }
        

        if (GameManager.擁有手槍)
        {
            Flashlight();
            SwitchingHand();
        }
        else if (!GameManager.擁有手槍)
        {
            switchingHand = false;
            anim.SetBool("PickUpWeapon", false);
        }

        if(Input.GetKey(KeyCode.I))
        {
            health += 100;
        }
        if(health >=100)
        {
            health = 100;   
        }
    }

    public void 標題消除玩家()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //GunHandFollowCursor();
        if (!Story_notmove)
        {
            PlayerDirection();
        }
        
    }

    //玩家面向 偵測鼠標調整角色左右面向
    public void PlayerDirection()
    {
        Vector3 difference = Orthographic.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        if(health > 0)
        {
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
        
    }

    /*
    public void GunHandFollowCursor()
    {
        
        handTargetF.transform.position = new Vector3(Orthographic.ScreenToWorldPoint(Input.mousePosition).x, Orthographic.ScreenToWorldPoint(Input.mousePosition).y);
        handTargetB.transform.position = new Vector3(Orthographic.ScreenToWorldPoint(Input.mousePosition).x, Orthographic.ScreenToWorldPoint(Input.mousePosition).y);
    }
    */

    //玩家移動
    public void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");

        if(health > 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftControl) && !sliding && CanSlideAgain)
            {
                Slide();
                PlayerHealth.玩家體力 -= 3;
            }
            else if (inputX > 0 && !sliding)//向右
            {
                if (Input.GetKey(KeyCode.LeftShift) && energy > runEnergyDecrease && direction == 1)
                {
                    Run();
                }
                else
                {
                    Walk();
                }
            }
            else if(inputX < 0 && !sliding)//向左
            {
                if (Input.GetKey(KeyCode.LeftShift) && energy > runEnergyDecrease && direction == -1)
                {
                    Run();
                }
                else
                {
                    Walk();
                }
            }
            else if(!sliding)
            {
                Idle();
            }
        }

        if(energyUnlimited)//體力無限模式
        {
            if (energy <= 100)
            {
                energy = 100;
            }
        }
        else//體力最大值限制
        {
            if (energy >= 100)
            {
                energy = 100;
            }
        }
    }

    //待機
    public void Idle()
    {
        energy += idleEnergyIncrease;//能量增加
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isWalkingBackward", false);
    }

    //走路
    public void Walk()
    {
        rg.velocity = new Vector2(inputX * walkSpeed, rg.velocity.y);
        energy += walkEnergyIncrease;//能量增加

        anim.SetBool("isRunning", false);
        anim.SetBool("isWalking", true);

        if (inputX > 0 && direction == -1 || inputX < 0 && direction == 1)
        {
            anim.SetBool("isWalkingBackward", true);
        }
        else
        {
            anim.SetBool("isWalkingBackward", false);
        }
    }

    //跑步
    public void Run()
    {
        rg.velocity = new Vector2(inputX * runSpeed, rg.velocity.y);
        //anim.Play("Run");
        //energy -= runEnergyDecrease;//能量消耗

        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", true);

        //喘氣聲
        if (energy <= breatheEnergy && !breath)
        {
            breath = true;
            //SoundManager.instance.PantSource();
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
        CanSlideAgain = false;
        sliding = true;
        anim.SetBool("isSliding", true);
        energy -= slideEnergyDecrease;
        rg.velocity = new Vector2(direction * slideSpeed, rg.velocity.y);
        collWalk.enabled = false;
        collSlide.enabled = true;
    }

    //滑行結束
    public void SlideOver()
    {
        Invoke("YouCanSlideAgain", SlideAgainTime);
        sliding = false;
        anim.SetBool("isSliding", false);
        rg.velocity = new Vector2(0, rg.velocity.y);
        collWalk.enabled = true;
        collSlide.enabled = false;
        PlayerHealth.回復體力=true;
    }

    public void YouCanSlideAgain()
    {
        CanSlideAgain = true;
    }

    //切換手臂
    void SwitchingHand()
    {
        if (GameManager.擁有手槍)
        {
            switchingHand = true;
            anim.SetBool("PickUpWeapon", true);
        }

        if (switchingHand && health > 0)
        {
            pistolHand.SetActive(true);
            handF.SetActive(false);
            handB.SetActive(false);
        }
        else if (!switchingHand && health > 0)
        {
            pistolHand.SetActive(false);
            handF.SetActive(true);
            handB.SetActive(true);
        }
    }

    //手持手電筒
    void Flashlight()
    {
        if (Input.GetMouseButtonDown(1))
        {
            flashlightSwitch = !flashlightSwitch;
        }

        if (Input.GetMouseButtonDown(1) && !flashlightSwitch) //注意!!配合(隱形)感測的按鍵一起釋放光源 預設按鍵:F
        {
            flashlight.SetActive(true);//開關物件
            flashlightMask.SetActive(true);
            SoundManager.instance.FlashLightOnSource();
        }
        else if (Input.GetMouseButtonDown(1) && flashlightSwitch) //注意!!配合(隱形)感測的按鍵一起釋放光源 預設按鍵:F
        {
            flashlight.SetActive(false);//開關物件
            flashlightMask.SetActive(false);
            SoundManager.instance.FlashLightOffSource();
        }
    }

    //手槍準星跟隨鼠標
    public void PistolTargetFollowCursor()
    {
        pistolTarget.transform.position = new Vector3(Orthographic.ScreenToWorldPoint(Input.mousePosition).x, Orthographic.ScreenToWorldPoint(Input.mousePosition).y);
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
            pistolHand.SetActive(false);
            Die();
        }
    }

    //死亡
    public void Die()
    {
        ToggleRagdoll(true);
    }
}
