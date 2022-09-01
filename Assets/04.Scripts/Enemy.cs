using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int 敵人生命最大值 = 100;
    public int 敵人生命 = 0;

    // Start is called before the first frame update
    void Start()
    {
        敵人生命 = 敵人生命最大值;
    }

    // Update is called once per frame
    void Update()
    {
        損血機制();
    }

    void 損血機制()
    {
        if(敵人生命 <= 0)
        {
            Destroy(gameObject);
        }

        else
        {

        }
    }


    void OnTriggerEnter2D(Collider2D Damage)
    {
        if(Damage.gameObject.tag == "Bullet")
        {
            敵人生命 -= 20;
        }
    }
}
