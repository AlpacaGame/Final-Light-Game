using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save_Load : MonoBehaviour
{
    public static Save_Load 存檔點;

    public GameObject 玩家;
    float 座標X;
    float 座標Y;
    float 座標Z;
    public static int 傳輸用;
    int 儲存場景幾號;
    public int 觀看幾號場景;    
    
    void Start()
    {
        if (存檔點 != null)
        {
            Destroy(gameObject);
            return;
        }

        存檔點 = this;
    }
    
    void Update()
    {
        觀看幾號場景 = 傳輸用;
        玩家 = GameObject.FindGameObjectWithTag("Player");
    }

    public void 存檔()
    {
        座標X = 玩家.transform.position.x;
        PlayerPrefs.SetFloat("位置 X", 座標X);
        座標Y = 玩家.transform.position.y;
        PlayerPrefs.SetFloat("位置 Y", 座標Y);
        座標Z = 玩家.transform.position.z;
        PlayerPrefs.SetFloat("位置 Z", 座標Z);

        儲存場景幾號 = 傳輸用;
        PlayerPrefs.SetInt("場景", 儲存場景幾號);
    }
    public void 讀檔()
    {
        if (PlayerPrefs.HasKey("位置 X") && PlayerPrefs.HasKey("位置 Y") && PlayerPrefs.HasKey("位置 Z"))
        {
            SceneManager.LoadScene(儲存場景幾號);

            座標X = PlayerPrefs.GetFloat("位置 X");
            座標Y = PlayerPrefs.GetFloat("位置 Y");
            座標Z = PlayerPrefs.GetFloat("位置 Z");
            Vector3 玩家座標 = new Vector3(座標X, 座標Y, 座標Z);
            玩家.transform.position = 玩家座標;

            
        }
    }
    public void 刪檔()
    {
        PlayerPrefs.DeleteAll();
    }
    /*
    void Update()
    {
        if (Input.GetKey(KeyCode.F1)) { 存檔(); }
        if (Input.GetKey(KeyCode.F2)) { 讀檔(); }
        if (Input.GetKey(KeyCode.F4)) { 刪檔(); }
    }
    */
}
