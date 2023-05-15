using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 新Pivot : MonoBehaviour
{

    public GameObject myPlayer;

    public static int 玩家面相 = 1;//用在玩家面相GunFire的玩家面向

    public Camera Orthographic;

    public bool RecordMode = false;

    [Space(5)]
    [Header("錄影用左右槍口開關")]
    public GameObject rightFirePoint;
    public GameObject leftFirePoint;

    public GameObject rifle_rightFirePoint;
    public GameObject rifle_leftFirePoint;

    private void FixedUpdate()
    {
        if(RecordMode)
        {
            Vector3 difference = Orthographic.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            if (rotationZ < -90 || rotationZ > 90)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);//180, 180, -rotationZ
                玩家面相 = -1;
                if(Gun_fire.切換武器編號 == 0)
                {
                    rightFirePoint.SetActive(false);//錄影用左右槍口開關
                    leftFirePoint.SetActive(true);

                    rifle_rightFirePoint.SetActive(false);
                    rifle_leftFirePoint.SetActive(false);
                }

                if (Gun_fire.切換武器編號 == 1)
                {
                    rifle_rightFirePoint.SetActive(false);
                    rifle_leftFirePoint.SetActive(true);

                    rightFirePoint.SetActive(false);//關閉
                    leftFirePoint.SetActive(false);
                }
            }

            else if (rotationZ > -90 || rotationZ < 90)
            {
                transform.localRotation = Quaternion.Euler(0, 0, rotationZ);//0, 0, rotationZ
                玩家面相 = 1;

                if (Gun_fire.切換武器編號 == 0)
                {
                    leftFirePoint.SetActive(false);//錄影用左右槍口開關
                    rightFirePoint.SetActive(true);

                    rifle_rightFirePoint.SetActive(false);
                    rifle_leftFirePoint.SetActive(false);
                }

                if (Gun_fire.切換武器編號 == 1)
                {
                    rifle_leftFirePoint.SetActive(false);
                    rifle_rightFirePoint.SetActive(true);

                    rightFirePoint.SetActive(false);//關閉
                    leftFirePoint.SetActive(false);
                }
            }
        }
        else
        {
            if (!玩家控制.切換使用敵人攝影機)
            {
                Vector3 difference = Orthographic.ScreenToWorldPoint(Input.mousePosition) - transform.position;

                difference.Normalize();

                float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                if (rotationZ < -90 || rotationZ > 90)
                {
                    transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);//180, 180, -rotationZ
                    玩家面相 = -1;
                }

                else if (rotationZ > -90 || rotationZ < 90)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, rotationZ);//0, 0, rotationZ
                    玩家面相 = 1;
                }
            }
        }
    }
}
