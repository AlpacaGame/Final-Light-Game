using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore_track : MonoBehaviour
{

    public float 飛行速度 = 2.0f;
    public Transform 偵測到玩家;
    public int 子彈消失時間 = 0;

    public int Hp;

    public GameObject 掉落物;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        偵測到玩家 = GameObject.Find("玩家偵測點").GetComponent<Transform>();
        

        transform.position = Vector2.MoveTowards(transform.position, 偵測到玩家.position, 飛行速度 * Time.deltaTime);

        if(Hp <= 0)
        {
            Destroy(gameObject);
            Hp = 0;
            Vector3 掉落物pos = this.transform.position + new Vector3(0, 0, 0);
            Instantiate(掉落物, 掉落物pos, transform.rotation);
        }

        //Destroy(gameObject, 子彈消失時間);
    }

    void OnTriggerEnter2D(Collider2D Damage)
    {
        if (Damage.gameObject.tag == "Bullet")
        {
            //anim.SetBool("isWalk", false);
            Hp -= 1;
            anim.SetBool("ishurt", true);
            Invoke("傷害動畫", 0.2f);
        }
    }

    void 傷害動畫()
    {
        anim.SetBool("ishurt", false);
    }
}
