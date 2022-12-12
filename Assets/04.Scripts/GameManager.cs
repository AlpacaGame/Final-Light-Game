﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class GameManager : MonoBehaviour
{

    public static bool 角色死亡;

    public static GameManager 遊戲主控;

    public bool 時間暫停 = false;
    public int 時間速度;

    public GameObject 玩家;
    public GameObject 重生點;

    public static bool 死亡重生 = false;

    public int 目前擁有彈匣數量;

    public bool 普通背景音樂, Boos背景音樂 = false;

    public GameObject 選單介面;
    public bool 開啟選單 = false;

    public int 關卡背景音樂 = 0;

    [Header("道具數量")]
    public bool 檢查道具擁有狀態 = true;
    public bool 觀看門禁卡, 觀看密碼鎖密碼, 觀看手槍 = false;
    public static bool 擁有門禁卡, 擁有密碼鎖密碼, 擁有手槍;
    public bool 觀看一次門禁卡, 觀看一次密碼鎖密碼, 觀看一次手槍;
    public GameObject 門禁卡, 密碼鎖密碼, 手槍;
    public float 觀看時間 = 0f;

    public int 點擊次數 = 0;

    public static Flowchart flowchartManager;

    void Awake()
    {
        
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
        //背景音樂();
        彈出選單();
        //監測是否正在對話();
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

        if (Input.GetKey(KeyCode.Alpha0))
        {
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
    /*
    void 時間控制器()
    {

        if (時間暫停)
        {
            時間速度 = 0;
            Time.timeScale = 0f;
        }
        else if (!時間暫停)
        {
            時間速度 = 1;
            Time.timeScale = 1f;
        }

        if (Input.GetKey(KeyCode.P))
        {
            時間暫停 = true;
        }
        else if (Input.GetKey(KeyCode.O))
        {
            時間暫停 = false;
        }

    }
    */
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
            Invoke("延遲重生", 0f);
        }

        
    }

    void 延遲重生()
    {
        if (死亡重生)
        {
            Vector3 重生點pos = this.transform.position + new Vector3(0, 0, 0);
            Application.LoadLevel(Application.loadedLevel);
            Instantiate(玩家, 重生點pos, 重生點.transform.rotation);
            死亡重生 = false;
            角色死亡 = false;
            //重生點.SetActive(false);

            //遊戲結束.SetActive(false);
        }
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
    }

    public void 離開遊戲()
    {
        Application.Quit(); // This line quits the application.
    }

    public void 關卡背景音樂切換(int BGM)
    {
        關卡背景音樂 = BGM;
        背景音樂();
    }

    public void 背景音樂()
    {

        
        if (關卡背景音樂 == 1)
        {
            SoundManager.instance.Background_SourceMusic();
            關卡背景音樂 = 0;
            //普通背景音樂 = false;
        }

        else if (關卡背景音樂 == 2)
        {
            SoundManager.instance.Boosfight_SourceMusic();
            關卡背景音樂 = 0;
            //Boos背景音樂 = false;
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
        else if (!開啟選單 && !正在對話)
        {
            選單介面.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void 監測是否正在對話()
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
    
    public void UI運作是否正常()
    {
        點擊次數 += 1;
    }

}
