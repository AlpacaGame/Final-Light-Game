using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGunsprite : MonoBehaviour
{
    public Sprite �����j, ����B�j; // �s��Sprite�Ϥ�

    private SpriteRenderer spriteRenderer; // SpriteRenderer���󪺰Ѧ�


    // Start is called before the first frame update
    void Start()
    {
        // ���o��e�C������W��SpriteRenderer����
        spriteRenderer = GetComponent<SpriteRenderer>();

        // �ˬd�O�_���\���oSpriteRenderer����
        /*
        if (spriteRenderer != null)
        {

        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Gun_fire.�����Z���s�� == 0 && GameManager.�֦���j)
        {
            spriteRenderer.sprite = �����j;
        }

        if (Gun_fire.�����Z���s�� == 1 && GameManager.�֦��B�j)
        {
            spriteRenderer.sprite = ����B�j;
        }
    }

}
