using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 新Pivot : MonoBehaviour
{

    public GameObject myPlayer;

    public static int 玩家面相 = 1;//用在玩家面相GunFire的玩家面向

    public Camera Orthographic;

    public bool RecordMode = false;

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
            }

            else if (rotationZ > -90 || rotationZ < 90)
            {
                transform.localRotation = Quaternion.Euler(0, 0, rotationZ);//0, 0, rotationZ
                玩家面相 = 1;
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
