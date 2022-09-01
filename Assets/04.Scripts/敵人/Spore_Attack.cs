using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore_Attack : MonoBehaviour
{
    public float 飛行速度 = 5.0f;
    public Transform 偵測到玩家;
    public bool 執行一次 = true;

    public Transform 只提供一次點;
    public int 子彈消失時間 = 1;


    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(Vector2.left * 飛行速度 * Time.deltaTime * 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

        偵測到玩家 = GameObject.Find("玩家偵測點").GetComponent<Transform>();
        if (執行一次)
        {
            只提供一次點.position = 偵測到玩家.position;
            //transform.LookAt(只提供一次點);
            
            執行一次 = false;
        }
        //Vector3 newPos1 = (只提供一次點.position);
        //transform.position = Vector3.Slerp(transform.position, 只提供一次點.position, Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, 只提供一次點.position, 飛行速度 * Time.deltaTime);
        //transform.position += transform.forward * 飛行速度 * Time.deltaTime;
        //transform.position += new Vector3(只提供一次點.position.x * Time.deltaTime, 只提供一次點.position.y *Time.deltaTime);
        //執行一次 = false;

        Destroy(gameObject, 子彈消失時間);
    }

    void OnTriggerEnter2D(Collider2D Damage)
    {
        if (Damage.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}
