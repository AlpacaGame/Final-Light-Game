using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void 繼續遊戲()
    {
        //SceneManager.LoadScene(2);
    }

    public void 開始遊戲()
    {
        SceneManager.LoadScene(2);
        SoundManager.instance.StartButtonSource();
    }

    public void 載入章節()
    {
        //SceneManager.LoadScene(2);
    }

    public void 離開遊戲()
    {
        Application.Quit(); // This line quits the application.
    }
}
