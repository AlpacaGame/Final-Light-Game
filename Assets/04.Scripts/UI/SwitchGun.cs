using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGun : MonoBehaviour
{

    public GameObject 手槍, 步槍;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gun_fire.切換武器編號 == 0)
        {
            手槍.SetActive(true);
            步槍.SetActive(false);
        }

        if (Gun_fire.切換武器編號 == 1)
        {
            手槍.SetActive(false);
            步槍.SetActive(true);
        }
    }
}
