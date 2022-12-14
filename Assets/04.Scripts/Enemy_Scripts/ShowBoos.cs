using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBoos : MonoBehaviour
{
    public GameObject MainCam;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        MainCam = GetComponent<GameObject>();
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
        SoundManager.instance.Boosfight_SourceMusic(); // 切換魔王背景音樂
        RippleEffect.PlayRippleEffect(3, 0.7f, 0.7f);
        EnemySpawner.StartEnemySpawn = true; //生小怪
        GameObject.Find("MainCamera").GetComponent<ScreenShake>().StartShake(1.5f, 0.18f);//螢幕震動
    }

    public void 移動()
    {
        SoundManager.instance.EnemyBoos_MoveSource();
    }
}
