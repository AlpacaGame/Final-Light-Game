using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore_Boos_random : MonoBehaviour
{
    public float 飛行速度 = 5.0f;
    public bool 執行一次 = true;
    public int 子彈消失時間 = 1;

    public int counter;
    public GameObject Shot;

    public bool 可開炮 = false;
    public bool State1, State2, State3, State4 = false;



    // Start is called before the first frame update
    void Start()
    {
        State1 = true;
        可開炮 = true;
    }

    void FixedUpdate()
    {
        counter++;

        Vector3 ShotAngle = new Vector3(0, 0, Random.Range(0, 360));

        //血條對應狀態
        if (Spore_Boos.on_hp >= 100)
        {
            State1 = true;
            State2 = false;
            State3 = false;
            State4 = false;
        }

        else if(Spore_Boos.on_hp <= 60 && Spore_Boos.on_hp >= 30)
        {
            State1 = false;
            State2 = true;
            State3 = false;
            State4 = false;
        }

        else if(Spore_Boos.on_hp <= 30 & Spore_Boos.on_hp >= 1)
        {
            State1 = false;
            State2 = false;
            State3 = true;
            State4 = false;
        }

        else if(Spore_Boos.on_hp <= 0)
        {
            State1 = false;
            State2 = false;
            State3 = false;
            State4 = false;
        }

        //每24禎跑這一串
        //5.10.15
        if (counter %  48 == 0 && 可開炮 && State1)
        {
            GameObject ShotObj1 = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
            ShotObj1.GetComponent<Spore_shot1>().InitAngle = Quaternion.Euler(ShotAngle);

            Invoke("關閉", 1f);
        }

        else if (counter % 48 == 0 && 可開炮 && State2)
        {
            GameObject ShotObj1 = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
            ShotObj1.GetComponent<Spore_shot1>().InitAngle = Quaternion.Euler(ShotAngle);

            Invoke("關閉", 3f);
        }

        else if (counter % 48 == 0 && 可開炮 && State3)
        {
            GameObject ShotObj1 = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
            ShotObj1.GetComponent<Spore_shot1>().InitAngle = Quaternion.Euler(ShotAngle);

            Invoke("關閉", 5f);
        }

        else if (State4)
        {
            print("死了");
        }


        //transform.localPosition = new Vector3(1f, 1, 1);
        //Destroy(gameObject, 子彈消失時間);
    }

    void 關閉()
    {
        可開炮 = false;
        Invoke("再度開啟", 7f);
    }

    void 再度開啟()
    {
        可開炮 = true;
    }


}
