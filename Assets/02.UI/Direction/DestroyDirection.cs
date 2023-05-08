using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDirection : MonoBehaviour
{
    public bool 反向開關 = true;
    void Update()
    {
        if(反向開關)
        {
            if (GameManager.擁有密碼鎖密碼)
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            if (!GameManager.擁有密碼鎖密碼)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
        }
    }
}
