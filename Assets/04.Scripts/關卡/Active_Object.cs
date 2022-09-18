using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Object : MonoBehaviour
{
    public GameObject 物品;

    public static bool 開關;

    void Awake()
    {
        開關 = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(開關)
        {
            顯示隱形牆();
        }
        else if(!開關)
        {
            關閉隱形牆();
        }
    }

    void 顯示隱形牆()
    {
        物品.SetActive(true);
    }

    void 關閉隱形牆()
    {
        物品.SetActive(false);
    }
}
