using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager : MonoBehaviour
{

    public static bool 角色死亡;

    public static GameManager 遊戲主控;

    public static bool 慢動作 = false;
    public float 時間速度;

    public GameObject 玩家;
    //public GameObject 場景內玩家;
    public GameObject 重生點;

    public static bool 死亡重生 = false;

    public int 目前擁有彈匣數量;

    //public bool 普通背景音樂, Boos背景音樂 = false;

    public GameObject 選單介面;
    public static bool 開啟選單 = false;

    public string 關卡背景音樂 = "";
    public bool 關閉主角 = false;

    [Header("道具數量")]
    public bool 檢查道具擁有狀態 = true;
    public bool 清除所有道具狀態 = false;
    public bool 觀看門禁卡, 觀看密碼鎖密碼, 觀看手槍 = false;
    public static bool 擁有門禁卡, 擁有密碼鎖密碼, 擁有手槍;
    public bool 觀看一次門禁卡, 觀看一次密碼鎖密碼, 觀看一次手槍;
    public GameObject 門禁卡, 密碼鎖密碼, 手槍;
    public float 觀看時間 = 0f;

    public int 點擊次數 = 0;

    public static Flowchart flowchartManager;

    private float fixedDeltaTime; //時間變量
    
    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }


    //靜態對話開關
    public static bool 正在對話
    {
        get
        {
            return flowchartManager.GetBooleanVariable("對話中");
        }
    }

    //靜態時停開關
    public static bool 正在時停
    {
        get
        {
            return flowchartManager.GetBooleanVariable("時停");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        觀看一次門禁卡 = true;
        觀看一次密碼鎖密碼 = true;
        觀看一次手槍 = true;
        if (遊戲主控 != null)
        {
            Destroy(gameObject);
            return;
        }
        遊戲主控 = this;
        DontDestroyOnLoad(this);
        //普通背景音樂 = true;
    }

    // Update is called once per frame
    void Update()
    {
        查詢BUG();
        重生();
        彈出選單();
        監測是否正在對話();
        時間控制器();
    }

    void 查詢BUG()
    {
        flowchartManager = GameObject.Find("對話管理器").GetComponent<Flowchart>();

        目前擁有彈匣數量 = Gun_fire.彈匣數量;

        if (檢查道具擁有狀態)
        {
            觀看門禁卡 = 擁有門禁卡;
            觀看密碼鎖密碼 = 擁有密碼鎖密碼;
            觀看手槍 = 擁有手槍;
        }

        if (清除所有道具狀態)
        {
            擁有門禁卡 = false;
            擁有密碼鎖密碼 = false;
            擁有手槍 = false;
            清除所有道具狀態 = false;
        }

        if (Input.GetKey(KeyCode.Alpha0))
        {
            角色死亡 = true;
            Application.LoadLevel(Application.loadedLevel);
        }

        else if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(2);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(3);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(4);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(5);
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            SceneManager.LoadScene(6);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            Gun_fire.彈匣數量++;
        }

    }
    
    void 時間控制器()
    {
        if (!正在時停 && !開啟選單)
        {
            if (慢動作)
            {
                Time.timeScale = 時間速度;
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
            else if (!慢動作)
            {
                Time.timeScale = 1.0f;
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
        }
        
        /*
        if (Input.GetKey(KeyCode.P))
        {
            時間暫停 = true;
        }
        else if (Input.GetKey(KeyCode.O))
        {
            時間暫停 = false;
        }
        */
        
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            慢動作 = true;
            //Time.timeScale = 0.2f;
            //Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            慢動作 = false;
            //Time.timeScale = 1.0f;
            //Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
        
    }
    
    void 重生()
    {
        if (重生點 == null)
        {
            重生點 = GameObject.Find("玩家重生點");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerHealth.玩家生命 -= 1;
        }

        if(角色死亡)
        {
            //Destroy(玩家, 0.5f);
            死亡重生 = true;
            Enemy_Zombie.看玩家死了沒 = true;
            Invoke("延遲重生", 0f);
        }

        
    }

    void 延遲重生()
    {
        if (死亡重生)
        {
            Vector3 重生點pos = 重生點.transform.position + new Vector3(0, 0, 0);
            Instantiate(玩家, 重生點pos, 重生點.transform.rotation);
            死亡重生 = false;
            角色死亡 = false;
            Invoke("延遲重生", 0.1f);
            //SceneManager.LoadScene(0);
            //重生點.SetActive(false);

            //遊戲結束.SetActive(false);
        }
    }
    void 重制遊戲()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    /*
    public void 死亡()
    {
        if (遊戲結束 == null)
        {
            遊戲結束 = GameObject.Find("遊戲結束布幕");
        }

        if (角色死亡 || Input.GetKey(KeyCode.Y))
        {
            遊戲結束.SetActive(true);
            //重生點.SetActive(true);
        }

        else if (Input.GetKey(KeyCode.T))
        {
            遊戲結束.SetActive(false);
        }
    }
    */

    public void 返回主選單()
    {
        SceneManager.LoadScene(0);
        清除所有道具狀態 = true;
        按鈕點擊繼續選單();
    }

    public void 離開遊戲()
    {
        清除所有道具狀態 = true;
        Application.Quit(); // This line quits the application.
    }

    public void 關卡背景音樂切換(string BGM)
    {
        關卡背景音樂 = BGM;
        switch (BGM)
        {
            case "普通關卡": // QUIT
                //objectToEnable.SetActive(false);
                SoundManager.instance.Background_SourceMusic();
                關閉主角 = false;
                //關卡背景音樂 = "0";
                break;

            case "魔王關卡": //CLEAR
                SoundManager.instance.Boosfight_SourceMusic();
                關閉主角 = false;
                //關卡背景音樂 = "0";
                break;

            case "標題畫面": //CLEAR
                SoundManager.instance.Menu_Bgm_SourceMusic();
                關閉主角 = true;
                玩家控制.不可重複.標題消除玩家();
                //玩家控制.不可重複.標題消除玩家();標題玩家消除
                //關卡背景音樂 = "0";
                break;

            default:
                //關卡背景音樂 = "0";
                break;
        }
    }


    public void 按鈕點擊繼續選單()
    {
        開啟選單 = !開啟選單;
    }

    public void 彈出選單()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            開啟選單 = !開啟選單;
        }

        if (開啟選單 && !正在對話)
        {
            選單介面.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (!開啟選單 && !正在對話 && !慢動作)
        {
            選單介面.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void 監測是否正在對話()
    {
        if(!開啟選單 && !慢動作)
        {
            if (正在時停)
            {
                Time.timeScale = 0f;
            }
            else if (!正在時停)
            {
                Time.timeScale = 1f;
            }
        }
        
    }
    
    public void UI運作是否正常()
    {
        點擊次數 += 1;
    }

    public void 第一關()
    {
        SceneManager.LoadScene(1);
    }
    public void 最後一關()
    {
        SceneManager.LoadScene(6);
        擁有門禁卡 = true;
        擁有密碼鎖密碼 = true;
        擁有手槍 = true;
    }
    public void 無限子彈()
    {
        Gun_fire.彈匣數量 += 100000;
    }
}
