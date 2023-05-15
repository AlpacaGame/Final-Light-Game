using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGun : MonoBehaviour
{

    public GameObject も簀, ˙簀;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Gun_fire.ち传猌竟絪腹 == 0 && GameManager.局Τも簀)
        {
            も簀.SetActive(true);
            ˙簀.SetActive(false);
        }

        if (Gun_fire.ち传猌竟絪腹 == 1 && GameManager.局Τ˙簀)
        {
            も簀.SetActive(false);
            ˙簀.SetActive(true);
        }
    }
}
