using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 滑套動畫 : MonoBehaviour
{
    Animator 開槍;

    public bool 觀看;

    public bool 可開火動畫開關;

    // Start is called before the first frame update
    void Start()
    {
        開槍 = GetComponent<Animator>();

        觀看 = !false;
    }

    // Update is called once per frame
    void Update()
    {

        開槍.SetTrigger("開槍結束");
        if (Input.GetMouseButtonDown(0) && Gun_fire.子彈 >= 1 && !PlayerSlide.滑鏟中 && Gun_fire.可開火開關)
        {
            開槍.SetTrigger("開槍");
            可開火動畫開關 = true;

        }
        else if (Input.GetMouseButtonDown(0) && Gun_fire.子彈 <= 0)
        {
            可開火動畫開關 = false;
            開槍.SetBool("已上膛", false);
            SoundManager.instance.No_BulletsSource();

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            開槍.SetBool("已上膛", true);
            SoundManager.instance.ReloadSource();
        }

    }


    public void 可開火()
    {
        Gun_fire.可開火開關 = true;
        觀看 = true;
    }



    public void 不可開火()
    {
        觀看 = false;
    }

}
