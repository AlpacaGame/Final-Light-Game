using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject 玩家;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("死亡畫面", 0);
        if (玩家 == null)
            玩家 = GameObject.FindGameObjectWithTag("Player");
    }

    public void 返回主畫面()
    {

    }

    public void 重新開始()
    {
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene(0);
        Time.timeScale = 1f;//時間運行
        //玩家移動.speed = 3f;
        GameManager.死亡重生 = true;
    }

    public void 讀取()
    {

    }
    public void 結束遊戲()
    {

    }

    void 死亡畫面()
    {
        //Time.timeScale = 0f;
        Destroy(玩家);
    }
}

