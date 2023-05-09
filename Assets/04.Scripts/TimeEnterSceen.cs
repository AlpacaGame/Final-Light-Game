using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeEnterSceen : MonoBehaviour
{

    public bool 按下任意鍵跳過;
    public bool 標題,預告片,Logo;
    public string 更改關卡名稱;
    public float 時間結束;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        時間結束 -= Time.deltaTime;

        if(Logo)
        {
            if (時間結束 <= 0 || (Input.anyKey))
            {
                結束播放回標題();
            }
        }
        if (標題)
        {
            if (時間結束 <= 0)
            {
                結束播放回標題();
            }
        }

    }

    public void 結束播放回標題()
    {
        SceneManager.LoadScene(更改關卡名稱);
    }
}
