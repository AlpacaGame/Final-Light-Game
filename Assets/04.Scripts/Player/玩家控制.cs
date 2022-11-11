using UnityEngine;

public class 玩家控制 : MonoBehaviour
{
    static 玩家控制 不可重複;

    [Header("基礎設定值")]
    //public float jumpPower = 10f;
    public float inputX = 0.0f;
    public float 走路速度 = 5f;
    public float 跑步速度 = 10f;
    public float 掛跑步速度 = 10f;
    public float 滑鏟速度 = 1f;
    public static bool 跑步中;
    public bool 跑步中觀看;

    public static int direction = 1;//左右面向(向右=1，向左=-1)
    bool 滑鏟中 = false;
    public bool isSliding = false;
    //public bool alive = true;//還活著
    public Camera Orthographic;
    public static bool 滑行測試開關 = false;

    public bool 手電筒開關 = true;
    public GameObject 手電筒, 手電筒遮罩;

    [Header("掛載元件")]
    private Rigidbody2D rg;
    private Animator anim;


    public static bool 可以心靈控制了 = false;
    public bool 觀看心靈控制 = false;

    public static bool 切換使用敵人攝影機 = false;
    public bool 觀看切換使用敵人攝影機 = false;

    public float 喘氣體力值 = 1.5f;
    public bool 喘氣中 = false;

    public bool 開啟切換手臂 = false;
    public GameObject 持槍手, 未持槍手;

    public bool 禁用滑鼠;

    private void FixedUpdate()//偵測鼠標調整角色左右面向
    {
        if (!滑行測試開關 && !切換使用敵人攝影機)
        {
            Vector3 difference = Orthographic.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            if(!禁用滑鼠)
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
    }

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (不可重複 != null)
        {
            Destroy(gameObject);
            return;
        }
        不可重複 = this;

        DontDestroyOnLoad(this);
    }

    void Update()
    {
        //&&!GameManager.正在對話
        if (!GameManager.角色死亡 && !切換使用敵人攝影機 && !GameManager.正在對話)
        {
            走路();
            跑步();
            滑鏟();
            if(GameManager.擁有手槍)
            {
                手持手電筒();
                切換手臂();
            }
           
        }
        心靈控制();
        if(GameManager.正在對話)
        {
            anim.Play("待機");
            rg.Sleep();
        }
    }

    void 走路()
    {
        inputX = Input.GetAxis("Horizontal");
        anim.SetBool("isWalk", false);
        if (!isSliding)
        {
            rg.velocity = new Vector2(inputX * 走路速度 * 掛跑步速度, rg.velocity.y);

        }

        if (inputX < 0 || inputX > 0)
        {

            if (!anim.GetBool("滑鏟中") && !anim.GetBool("isRun"))
            {
                anim.SetBool("isWalk", true);
            }
        }

    }

    public void 走路音效()
    {
        SoundManager.instance.MoveSource();
    }

    void 跑步()
    {
        //按下shift+a或d鍵，速度=跑步速度 且 播放跑步動畫
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && PlayerHealth.玩家體力 >= 0.03f)//跑步
        {
            //PlayerHealth.玩家體力 -= 0.3f;
            掛跑步速度 = 跑步速度;
            //跑步速度 = 3f;
            //PlayerHealth.instance.耗力(0.03f);
            PlayerHealth.玩家體力 -= 0.03f;
            PlayerHealth.回復體力 = false;
            anim.SetBool("isRun", true);
            anim.SetBool("isWalk", false);
        }

        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && PlayerHealth.玩家體力 >= 0.03f)//跑步
        {
            //PlayerHealth.玩家體力 -= 0.3f;
            掛跑步速度 = 跑步速度;
            //跑步速度 = 3f;
            //PlayerHealth.instance.耗力(0.03f);
            PlayerHealth.玩家體力 -= 0.03f;
            PlayerHealth.回復體力 = false;
            anim.SetBool("isRun", true);
            anim.SetBool("isWalk", false);
        }

        else
        {
            anim.SetBool("isRun", false);
            掛跑步速度 = 1f;
            //跑步速度 = 1f;
            PlayerHealth.回復體力 = true;
            跑步中 = false;
            跑步中觀看 = false;
        }

        if (PlayerHealth.玩家體力 <= 喘氣體力值 && !喘氣中)
        {
            喘氣中 = true;
            SoundManager.instance.PantSource();
            Invoke("喘氣聲間隔", 5);
        }
    }

    void 喘氣聲間隔()
    {
        喘氣中 = false;
    }

    void 滑鏟()
    {

        if (Input.GetKeyDown(KeyCode.C) && !isSliding && PlayerHealth.玩家體力 >= 25f)
        {
            //Invoke("結束滑鏟", 4f);
            anim.SetBool("滑鏟中", true);
            PlayerHealth.玩家體力 -= 25f;
            isSliding = true;
            rg.velocity = new Vector2(direction * 滑鏟速度 , rg.velocity.y);
            //Invoke("結束滑鏟", 0.4f);
            //rg.AddForce(Vector2.right * 滑鏟速度);

            if (direction == 1)
            {
                //rigidbody.AddForce(Vector2.right * SlideSpeed);

                滑行測試開關 = true;
                //測試滑行開關右 = true;
            }
            else if (direction == -1)
            {
                //rigidbody.AddForce(Vector2.left * SlideSpeed);
                //rigidbody.velocity = new Vector2(玩家控制.direction * SlideSpeed * SlideSpeed1, rigidbody.velocity.y);
                滑行測試開關 = true;
                //測試滑行開關左 = true;
            }
        }
    }

    public void 結束滑鏟()
    {
        anim.SetBool("滑鏟中", false);
        isSliding = false;
        滑行測試開關 = false;
    }

    void 手持手電筒()
    {
        if (Input.GetMouseButtonDown(1))
        {
            手電筒開關 = !手電筒開關;
        }


        if (Input.GetMouseButtonDown(1) && !手電筒開關) //注意!!配合(隱形)感測的按鍵一起釋放光源 預設按鍵:F
        {
            手電筒.SetActive(true);//開關物件
            手電筒遮罩.SetActive(true);
            SoundManager.instance.FlashLightOnSource();
        }
        else if (Input.GetMouseButtonDown(1) && 手電筒開關) //注意!!配合(隱形)感測的按鍵一起釋放光源 預設按鍵:F
        {
            手電筒.SetActive(false);//開關物件
            手電筒遮罩.SetActive(false);
            SoundManager.instance.FlashLightOffSource();
        }

    }

    void 心靈控制()
    {
        觀看心靈控制 = 可以心靈控制了;
        觀看切換使用敵人攝影機 = 切換使用敵人攝影機;

        if (Input.GetKey(KeyCode.L))
        {
            可以心靈控制了 = true;
        }

        else if (Input.GetKey(KeyCode.K))
        {
            可以心靈控制了 = false;
        }


        if (Input.GetKeyDown(KeyCode.Q) && 可以心靈控制了)
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isRun", false);
            anim.SetBool("滑鏟中", false);
            切換使用敵人攝影機 = true;
            可以心靈控制了 = false;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && !可以心靈控制了)
        {
            切換使用敵人攝影機 = false;
            //可以心靈控制了 = true;
        }

    }

    void 切換手臂()
    {
        if(GameManager.擁有手槍)
        {
            開啟切換手臂 = true;
        }

        if (開啟切換手臂)
        {
            持槍手.SetActive(true);
            未持槍手.SetActive(false);
        }
        else if (!開啟切換手臂)
        {
            持槍手.SetActive(false);
            未持槍手.SetActive(true);
        }
    }

    public void Anime_End()//甦醒動畫結束
    {
        Pivot_Head.AnimeEnd = true;
    }
}