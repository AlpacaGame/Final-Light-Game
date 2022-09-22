using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boos_Component_damage : MonoBehaviour
{
    public int 給予分區傷害數值 = 0;

    public static int 分享數值;

    public Spore_Boos Boos主體;

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
            Boos主體.Hp -= 給予分區傷害數值;
        }
    }
}