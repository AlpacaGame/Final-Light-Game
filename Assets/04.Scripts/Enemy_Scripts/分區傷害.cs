using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 分區傷害 : MonoBehaviour
{

    public int 給予分區傷害數值 = 0;

    public static int 分享數值;

    public 敵人health 殭屍主體;

    // Start is called before the first frame update
    void Start()
    {
        分享數值 = 給予分區傷害數值;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D Damage)
    {
        if (Damage.gameObject.tag == "Bullet")
        {
            殭屍主體.敵人生命 -= 給予分區傷害數值;
        }
    }
}
