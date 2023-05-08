using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public static bool 回復體力;
    public bool 回復體力觀看;

    public float 回復體力速度 = 1;

    public int 玩家生命最大值 = 100;
    public static int 玩家生命 = 0;
    public int 觀看生命 = 0;

    public int 玩家體力最大值 = 3;
    public static float 玩家體力 = 0;
    public float 觀看體力 = 0;

    public int 玩家子彈最大值 = 8;
    public static int 玩家子彈 = 0;
    public int 預計消耗子彈量 = 0;

    public LifeBar 血量量度計;
    public StrengthBar 體力量度計;
    public 子彈UI 子彈量度計;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        玩家生命 = 玩家生命最大值;
        血量量度計.血量極限(玩家生命最大值);

        玩家體力 = 玩家體力最大值;
        體力量度計.體力極限(玩家體力最大值);

        玩家子彈 = 玩家子彈最大值;
        子彈量度計.子彈極限(玩家子彈最大值);
    }

    // Update is called once per frame
    void Update()
    {
        if (血量量度計 == null)
        {
            血量量度計 = GameObject.Find("血量條(我設一條命)(底下的東西我隱藏了)").GetComponent<LifeBar>();
        }
        if (體力量度計 == null)
        {
            體力量度計 = GameObject.Find("體力條(底下的東西我隱藏了)").GetComponent<StrengthBar>();
        }
        if (子彈量度計 == null)
        {
            子彈量度計 = GameObject.Find("子彈條").GetComponent<子彈UI>();
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            玩家生命 -= 20;
            耗力(3);
            
        }

        損血機制();
        耗力機制();
        //滑鏟消耗();
        子彈消耗機制();
    }

    void 損血機制()
    {
        血量量度計.血量剩餘(玩家生命);
        觀看生命 = 玩家生命;
        

        if (玩家生命 <= 0)
        {
            GameManager.角色死亡 = true;
            Destroy(gameObject);
            //GameManager.死亡重生 = true;
        }

        if (玩家生命 <= 0)
        {
            玩家生命 = 0;
        }
        else if (玩家生命 >= 100)
        {
            玩家生命 = 100;
        }
    }

    void 耗力機制()
    {
        體力量度計.體力剩餘(玩家體力);
        觀看體力 = 玩家體力;
        
            

        if (回復體力)
        {
            回力(回復體力速度);
            回復體力觀看 = true;
        }

        if (玩家體力 <= 0)
        {
            玩家體力 = 0;
            回復體力 = true;
        }
        else if (玩家體力 >= 玩家體力最大值)
        {
            玩家體力 = 玩家體力最大值;
            回復體力 = false;
            回復體力觀看 = false;
        }
    }
    /*
    void 滑鏟消耗()
    {
        if (PlayerSlide.滑鏟中)
        {
            玩家體力 -= 70f * Time.deltaTime;
        }
    }
    */
    void 子彈消耗機制()
    {
        
            
        預計消耗子彈量 = Gun_fire.子彈;

        子彈量度計.子彈剩餘(預計消耗子彈量);
    }

    public void 耗血(int 傷害值)
    {
        if (玩家生命 > 0 && 玩家生命 <= 100)
        {
            玩家生命 -= 傷害值;
            血量量度計.血量剩餘(玩家生命);
        }
    }
    public void 回血(int 修復值)
    {
        if (玩家生命 >= 0 && 玩家生命 < 100)
        {
            玩家生命 += 修復值;
            血量量度計.血量剩餘(玩家生命);
        }
    }

    public void 耗力(float 傷害值)
    {

        if (玩家體力 <= 0 && 玩家體力 >= 3)
        {
            玩家體力 -= 傷害值;
            體力量度計.體力剩餘(玩家體力);
        }
    }

    public void 回力(float 修復值)
    {
        if (玩家體力 > -999 && 玩家體力 < 3)
        {
            玩家體力 += 修復值 * Time.fixedDeltaTime;
            體力量度計.體力剩餘(玩家體力);
        }
    }

}
