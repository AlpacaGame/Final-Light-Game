using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeEnterSceen : MonoBehaviour
{
    public string ������d�W��;
    public float �ɶ�����;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        �ɶ����� -= Time.deltaTime;
        if (�ɶ����� <= 0)
        {
            ��������^���D();
        }
    }

    public void ��������^���D()
    {
        SceneManager.LoadScene(������d�W��);
    }
}
