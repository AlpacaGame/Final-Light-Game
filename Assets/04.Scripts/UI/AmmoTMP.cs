using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AmmoTMP : MonoBehaviour
{
    public TextMeshProUGUI �l�u;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        �l�u = transform.GetComponent<TextMeshProUGUI>();

        if(Gun_fire.�����Z���s�� == 0)//��j
        {
            string �Y�ɦ^�X�l�u�ƶq = Gun_fire.�l�u.ToString();

            // �N��r�]�w��UI Text��text�ݩ�
            �l�u.text = �Y�ɦ^�X�l�u�ƶq;
        }

        if (Gun_fire.�����Z���s�� == 1)//�B�j
        {
            string �Y�ɦ^�X�l�u�ƶq = Gun_fire.rifleAmmo.ToString();

            // �N��r�]�w��UI Text��text�ݩ�
            �l�u.text = �Y�ɦ^�X�l�u�ƶq;
        }

    }
}
