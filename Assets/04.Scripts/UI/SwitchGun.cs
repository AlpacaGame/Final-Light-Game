using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGun : MonoBehaviour
{

    public GameObject ��j, �B�j;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gun_fire.�����Z���s�� == 0 && GameManager.�֦���j)
        {
            ��j.SetActive(true);
            �B�j.SetActive(false);
        }

        if (Gun_fire.�����Z���s�� == 1 && GameManager.�֦��B�j)
        {
            ��j.SetActive(false);
            �B�j.SetActive(true);
        }
    }
}
