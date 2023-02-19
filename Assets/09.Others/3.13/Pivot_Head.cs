using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot_Head : MonoBehaviour
{
    public GameObject myPlayer;
    public Camera Orthographic;
    public static bool AnimeEnd = false;

    private void FixedUpdate()
    {
        if(AnimeEnd)
        {
            Vector3 difference = Orthographic.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            difference.Normalize();

            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            
            if (rotationZ > 90)//left up
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ/2 -90);
            }
            else if(rotationZ < -90)//left down
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ/2 +90);
            }
            else if (rotationZ > -90 || rotationZ < 90)//right
            {
                transform.localRotation = Quaternion.Euler(0, 0, rotationZ/2);
            }
            
            /*
             * 修改前頭部骨折程式
            if (rotationZ < -90 || rotationZ > 90)//left down
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
            else if (rotationZ > -90 || rotationZ < 90)//right
            {
                transform.localRotation = Quaternion.Euler(0, 0, rotationZ);
            }
            */
        }
    }
}
