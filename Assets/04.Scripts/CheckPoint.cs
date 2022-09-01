using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool 可記錄 = false;

    public int 此場景幾號 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        紀錄();
        灌輸場景號碼();
    }

    void 紀錄()
    {
        if (可記錄 && Input.GetKeyDown(KeyCode.E))
        {
            Save_Load.存檔點.存檔();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Save_Load.存檔點.讀檔();
        }

        else if (Input.GetKeyDown(KeyCode.F4))
        {
            Save_Load.存檔點.刪檔();
        }
    }

    void 灌輸場景號碼()
    {
        Save_Load.傳輸用 = 此場景幾號;
    }

    void OnTriggerEnter2D(Collider2D Save)
    {
        if (Save.CompareTag("Player"))
        {
            可記錄 = true;
        }
    }

    void OnTriggerEixt2D(Collider2D Save)
    {
        if (Save.CompareTag("Player"))
        {
            可記錄 = false;
        }
    }
}
