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
        /*
        if(Input.GetKey(KeyCode.K))
        {
            RippleEffect.PlayRippleEffect(3, 0.6f, 0.6f);
        }
        */
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
        SoundManager.instance.EnemyBoos_AttackSource();//怒吼音效
        //RippleEffect.PlayEffect = true;
        SoundManager.instance.Boosfight_SourceMusic(); // 切換魔王背景音樂
        RippleEffect.PlayRippleEffect(3, 0.7f, 0.7f);
    }

    public void 移動()
    {
        SoundManager.instance.EnemyBoos_MoveSource();
    }
}
