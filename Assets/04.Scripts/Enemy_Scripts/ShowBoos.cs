using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBoos : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void 執行動畫()
    {

    }
    void 結束掉頭()
    {

    }

    void OnTriggerEnter2D(Collider2D Boos)
    {
        if (Boos.gameObject.tag == "Player")
        {
            anim.Play("Roar");
        }
    }

    public void 怒吼()
    {
        SoundManager.instance.EnemyBoos_AttackSource();
    }

    public void 移動()
    {
        SoundManager.instance.EnemyBoos_MoveSource();
    }
}
