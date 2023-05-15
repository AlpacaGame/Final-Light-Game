using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AmmoTMP : MonoBehaviour
{
    public TextMeshProUGUI 紆;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        紆 = transform.GetComponent<TextMeshProUGUI>();

        if(Gun_fire.ち传猌竟絪腹 == 0)//も簀
        {
            string 鮔紆计秖 = Gun_fire.紆.ToString();

            // 盢ゅ砞﹚UI Texttext妮┦
            紆.text = 鮔紆计秖;
        }

        if (Gun_fire.ち传猌竟絪腹 == 1)//˙簀
        {
            string 鮔紆计秖 = Gun_fire.rifleAmmo.ToString();

            // 盢ゅ砞﹚UI Texttext妮┦
            紆.text = 鮔紆计秖;
        }

    }
}
