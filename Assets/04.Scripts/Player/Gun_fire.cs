using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_fire : MonoBehaviour
{
    public int 彈匣 = 8;
    public static int 子彈 = 8;
    public int 觀看子彈數量;
    public static int 彈匣數量 = 2;
    public bool 填充子彈 = false;

    public float 開火時間 = 1.5f;
    public float 下一槍;

    public GameObject 子彈預設物;

    public GameObject 彈殼動畫;

    public GameObject 左槍口, 右槍口;

    public GameObject 槍口亮光;

    public static bool 可開火開關 = true;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        觀看子彈數量 = 子彈;
        if (彈匣數量 >= 1 && Input.GetKeyDown(KeyCode.R))
        {
            子彈 = 彈匣;
            彈匣數量 -= 1;
        }

        if (子彈 >= 1 && Input.GetMouseButtonDown(0) && 新Pivot.玩家面相 == -1 && !PlayerSlide.滑鏟中 && 可開火開關)
        {
            Vector3 槍口pos = this.transform.position + new Vector3(0, 0, 0);
            Vector3 槍口後pos = this.transform.position + new Vector3(0.5f, 0, 0);
            Instantiate(子彈預設物, 槍口pos, 左槍口.transform.rotation);
            Instantiate(彈殼動畫, 槍口pos, 左槍口.transform.rotation);
            Instantiate(槍口亮光, 槍口pos, 左槍口.transform.rotation);
            子彈 -= 1;
            SoundManager.instance.FireSource();

        }

        else if (子彈 >= 1 && Input.GetMouseButtonDown(0) && 新Pivot.玩家面相 == 1 && !PlayerSlide.滑鏟中 && 可開火開關)
        {
            Vector3 槍口pos = this.transform.position + new Vector3(0, 0, 0);
            Vector3 槍口後pos = this.transform.position + new Vector3(-0.5f, 0, 0);
            Instantiate(子彈預設物, 槍口pos, 右槍口.transform.rotation);
            Instantiate(彈殼動畫, 槍口pos, 右槍口.transform.rotation);
            Instantiate(槍口亮光, 槍口pos, 右槍口.transform.rotation);
            子彈 -= 1;
            SoundManager.instance.FireSource();

        }
        else if (子彈 == 0 && Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.No_BulletsSource();
        }

        if (新Pivot.玩家面相 == 1)
        {
            右槍口.SetActive(true);
            左槍口.SetActive(false);
        }

        else if (新Pivot.玩家面相 == -1)
        {
            左槍口.SetActive(true);
            右槍口.SetActive(false);
        }
    }
}