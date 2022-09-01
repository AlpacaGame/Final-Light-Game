using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{

    static DontDestroyUI 遊戲UI;

    void Start()
    {
        if (遊戲UI != null)
        {
            Destroy(gameObject);
            return;
        }

        遊戲UI = this;

        DontDestroyOnLoad(this);
    }
}
