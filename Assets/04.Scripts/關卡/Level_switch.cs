using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_switch : MonoBehaviour
{
    public bool ���ռ��D����;

    public string ���D�I������;//1�O���q���d 2�OBoos���d


    // Start is called before the first frame update
    void Start()
    {

        GameManager.�C���D��.���d�I�����֤���(���D�I������);
    }

    // Update is called once per frame
    void Update()
    {
        if(���ռ��D����)
        {
            ���D����();
            ���ռ��D���� = false;

        }    
    }

    void ���D����()
    {
        GameManager.�C���D��.���d�I�����֤���(���D�I������);
    }
}
