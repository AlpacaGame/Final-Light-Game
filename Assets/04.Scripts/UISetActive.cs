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
        
        else if (�߬B�j�K && GameManager.�֦���j)
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

        else if (�ɦ� && GameManager.�֦��ɦ�)
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

    }
}
