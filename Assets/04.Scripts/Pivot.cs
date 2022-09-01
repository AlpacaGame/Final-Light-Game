using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{

    public GameObject myPlayer;

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y , difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90) //假設 你的角度小於-30或是大於30度就會執行以下的指令
        {

            //基本上人物面向都會從右邊開始
            //人物面向右
            if (myPlayer.transform.localScale.x == 1) //再假設角色大小在 正1 時並改變角度大於30度或小於-30度就會翻轉
            {


                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);


            }

            //人物面向左
            else if (myPlayer.transform.localScale.x == -1) //再假設角色大小在 負1 時並改變角度大於30度或小於-30度就會翻轉
            {


                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);


            }
            
        }

        else if (rotationZ > -90 || rotationZ < 90) //假設 你的角度大於-30或是小於30度就會執行以下的指令
        {


            //人物面向右
            if (myPlayer.transform.localScale.x == 1) //跟以上一樣只是相反角度而已
            {


                transform.localRotation = Quaternion.Euler(0, 0, rotationZ);


            }
            //人物面向左
            else if (myPlayer.transform.localScale.x == -1)
            {


                transform.localRotation = Quaternion.Euler(0, 180, rotationZ);


            }
        }
    }
}

