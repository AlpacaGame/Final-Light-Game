using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetActive : MonoBehaviour
{
    public GameObject ���}UI;

    public bool �L����, �߬B�j�K, �ɦ�;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(�L����)
        {
            if (GameManager.UI�}��)
            {
                ���}UI.SetActive(true);
            }
            else if (!GameManager.UI�}��)
            {
                ���}UI.SetActive(false);
            }
        }    
        
        if (�߬B�j�K)
        {
            if (GameManager.�֦���j || GameManager.�֦��B�j)
            {
                if (GameManager.UI�}��)
                {
                    ���}UI.SetActive(true);
                }
                else if (!GameManager.UI�}��)
                {
                    ���}UI.SetActive(false);
                }
            }

            if (!GameManager.�֦���j && !GameManager.�֦��B�j)
            {
                ���}UI.SetActive(false);
            }
        }

        if (�ɦ�)
        {
            if (GameManager.�֦��ɦ�)
            {
                if (GameManager.UI�}��)
                {
                    ���}UI.SetActive(true);
                }
                else if (!GameManager.UI�}��)
                {
                    ���}UI.SetActive(false);
                }
            }

            if (!GameManager.�֦��ɦ�)
            {
                ���}UI.SetActive(false);
            }
            
        }

    }
}
