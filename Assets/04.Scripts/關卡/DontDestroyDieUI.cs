using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyDieUI : MonoBehaviour
{
    static DontDestroyDieUI 死亡畫面;

    void Start()
    {
        if (死亡畫面 != null)
        {
            Destroy(gameObject);
            return;
        }
        死亡畫面 = this;

        DontDestroyOnLoad(this);
    }
}
