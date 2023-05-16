using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBoos : MonoBehaviour
{
    public GameObject MainCam;
    private Animator anim;

    public static bool 動畫開關;
    public GameObject 爆炸;
    public GameObject ventLaunch;

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
        執行動畫();
    }

    void 執行動畫()
    {
        if(動畫開關)
        {
            anim.Play("Roar");
            GameManager.故事模式 = true;
            動畫開關 = false;
        }
    }
    void 結束掉頭()
    {

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

    public void 衝撞聲()
    {
        GameManager.故事模式 = false;
        SoundManager.instance.EnemyBoss_ExplosionSource();
        爆炸.SetActive(true);
        ventLaunch.GetComponent<ObjectLaunch>().Launch();
    }
}
