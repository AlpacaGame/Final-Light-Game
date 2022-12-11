using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float 加速度 = 0;
    public float 子彈速度 = 230;

    public GameObject 子彈特效動畫;
    public GameObject 子彈傷害動畫;

    public int 子彈消失時間 = 1;

    public int damage = 20;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (子彈速度 / 10) * Time.deltaTime);
        子彈速度 += 加速度 * Time.deltaTime;

        //transform.Translate(Vector3.right * Time.deltaTime * 子彈速度);
        
        Destroy(gameObject, 子彈消失時間);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            Instantiate(子彈傷害動畫, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        else if (hitInfo.gameObject.tag == "floor")
        {
            Instantiate(子彈特效動畫, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        /*
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        */
        Instantiate(子彈特效動畫, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
