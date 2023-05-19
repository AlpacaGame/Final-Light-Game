using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore_Boos_random : MonoBehaviour
{
    public float 飛行速度 = 5.0f;
    public bool 執行一次 = true;
    public bool 一次回滿 = true;
    public bool 階段五不重複;
    public static bool 無敵 = false;
    public int 子彈消失時間 = 1;

    public int counter;
    public GameObject Shot;
    public GameObject Shot2;

    public bool 可開炮 = false;
    public bool State1, State2, State3, State4, State5, State6 = false;

    public GameObject deathEffect;

    [Space(5)]
    [Header("切換模式生命值參數")]
    public int State1Health = 900;
    public int State2Health = 600;
    public int State3Health = 400;
    public int State4Health = 200;

    [Space(5)]
    [Header("吼叫")]
    public bool Roar = true;
    public int roarCount = 1;

    public int randomInt;
    

    // Start is called before the first frame update
    void Start()
    {
        State1 = true;
        可開炮 = true;
        Spore_Boos.回血 = true;
        階段五不重複 = true;
    }

    void 一次回滿MAX()
    {
        一次回滿 = false;
    }

    void FixedUpdate()
    {
        if (!一次回滿)
        {
            Spore_Boos.回血 = false;
            無敵 = false;

            
        }
        
        if(一次回滿)
        {
            if(階段五不重複)
            {
                if (State1 || State2)
                {
                    Spore_Boos.回血數字 = 5;
                }

                if (State3 || State4)
                {
                    Spore_Boos.回血數字 = 20;
                }

            }

            if (State5 && !階段五不重複)
            {
                Spore_Boos.回血數字 = 250;

                無敵 = true;
                
                //Invoke("一次回滿MAX", 7.5f);
            }

            if (Spore_Boos.on_hp >= 1800 && !階段五不重複)
            {
                一次回滿 = false;
            }
        }

        

        if (DoorLock.StartBossFight)
        {
            counter++;

            Vector3 ShotAngle = new Vector3(0, 0, Random.Range(0, 360));

            //血條對應狀態
            if (Spore_Boos.on_hp >= State1Health)
            {
                State1 = false;
                State2 = true;
                State3 = false;
                State4 = false;
                State5 = false;
                State6 = false;
            }

            else if (Spore_Boos.on_hp <= State2Health && Spore_Boos.on_hp >= State3Health)
            {
                State1 = false;
                State2 = false;
                State3 = true;
                State4 = false;
                State5 = false;
                State6 = false;
            }

            else if (Spore_Boos.on_hp <= State3Health && Spore_Boos.on_hp >= State4Health)
            {
                State1 = false;
                State2 = false;
                State3 = false;
                State4 = true;
                State5 = false;
                State6 = false;
            }

            else if (Spore_Boos.on_hp <= State4Health && Spore_Boos.on_hp >= 1)
            {
                State1 = false;
                State2 = false;
                State3 = false;
                State4 = false;
                State5 = true;
                State6 = false;

                階段五不重複 = false;
            }

            else if (Spore_Boos.on_hp <= 0)
            {
                State1 = false;
                State2 = false;
                State3 = false;
                State4 = false;
                State5 = false;
                State6 = true;
            }

            //每24禎跑這一串
            //5.10.15
            if (counter % 48 == 0 && 可開炮 && State1)
            {
                GameObject ShotObj1 = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
                ShotObj1.GetComponent<Spore_shot1>().InitAngle = Quaternion.Euler(ShotAngle);

                Invoke("關閉", 1);
            }

            else if (counter % 48 == 0 && 可開炮 && State2)
            {
                GameObject ShotObj1 = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
                ShotObj1.GetComponent<Spore_shot1>().InitAngle = Quaternion.Euler(ShotAngle);

                Invoke("關閉", 3);
            }

            else if (counter % 48 == 0 && 可開炮 && State3)
            {
                GameObject ShotObj1 = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
                ShotObj1.GetComponent<Spore_shot1>().InitAngle = Quaternion.Euler(ShotAngle);

                Invoke("關閉", 5);
            }

            else if (counter % 12 == 0 && 可開炮 && State4)
            {
                GameObject ShotObj1 = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
                ShotObj1.GetComponent<Spore_shot1>().InitAngle = Quaternion.Euler(ShotAngle);

                Invoke("關閉", 7);
            }

            else if (State6)
            {
                print("死了");
                Die();
                State1 = false;
                State2 = false;
                State3 = false;
                State4 = false;
                State5 = false;
                State6 = false;
            }

            //孢子子彈2
            if (counter % 96 == 0 && 可開炮 && State1)
            {
                GameObject ShotObj2 = Instantiate(Shot2, transform.position, new Quaternion(0, 0, 0, 0));
            }

            if (counter % 72 == 0 && 可開炮 && State2)
            {
                GameObject ShotObj2 = Instantiate(Shot2, transform.position, new Quaternion(0, 0, 0, 0));
            }

            if (counter % 48 == 0 && 可開炮 && State3)
            {
                GameObject ShotObj2 = Instantiate(Shot2, transform.position, new Quaternion(0, 0, 0, 0));
            }
            /*
            if (counter % 8 == 0 && 可開炮 && State4)
            {
                GameObject ShotObj2 = Instantiate(Shot2, transform.position, new Quaternion(0, 0, 0, 0));
            }
            */
            //transform.localPosition = new Vector3(1f, 1, 1);
            //Destroy(gameObject, 子彈消失時間);
        }
    }

    void 關閉()
    {
        可開炮 = false;
        Invoke("再度開啟", 7f);
        roarCount = 1;
    }

    void 再度開啟()
    {
        可開炮 = true;
        
        if(Roar && roarCount >= 1)
        {
            GameObject.Find("MainCamera").GetComponent<ScreenShake>().StartShake(1.5f, 0.18f);//螢幕震動4 .5
            SoundManager.instance.EnemyBoos_AttackSource2();//怒吼音效
            roarCount -= 1;
        }
    }

    //死亡
    public void Die()
    {
        GameObject.Find("MainCamera").GetComponent<ScreenShake>().StartShake(6f, 0.25f);//螢幕震動
        Instantiate(deathEffect, transform.position, Quaternion.identity);//特效
        Invoke("Disappear", 5);
        //Spore_Boos.回血 = false;
    }

    public void Disappear()
    {
        SoundManager.instance.EnemyBoss_DeathSource();//死亡音效
        Destroy(gameObject);
    }
}
