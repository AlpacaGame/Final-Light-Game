using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class 跑步 : MonoBehaviour
{
    static public bool 跑步中;
    public bool 跑步中觀看;

    public AudioClip 喘氣音效;
    public bool 喘氣中;
    public float 喘氣體力值 = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        喘氣中 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && PlayerHealth.玩家體力 >= 0.3f)//跑步
        {
            transform.Translate(Vector2.left * 4f * Time.deltaTime);
            PlayerHealth.玩家體力 -= 0.3f;
            PlayerHealth.回復體力 = false;
            跑步中 = true;
            跑步中觀看 = true;
        }

        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && PlayerHealth.玩家體力 >= 0.3f)//跑步
        {
            transform.Translate(Vector2.right * 4f * Time.deltaTime);
            PlayerHealth.玩家體力 -= 0.3f;
            PlayerHealth.回復體力 = false;
            跑步中 = true;
            跑步中觀看 = true;
        }

        else
        {
            PlayerHealth.回復體力 = true;
            跑步中 = false;
            跑步中觀看 = false;
        }

        if (PlayerHealth.玩家體力 <= 喘氣體力值 && !喘氣中)
        {
            GetComponent<AudioSource>().PlayOneShot(喘氣音效);
            喘氣中 = true;

            Invoke("喘氣聲間隔", 5);//間隔五秒
        }
    }

    void 喘氣聲間隔()
    {
        喘氣中 = false;
    }
}
