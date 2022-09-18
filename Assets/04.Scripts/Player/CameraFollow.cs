using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //static CameraFollow 不可重複;

    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target, target1;

    public bool 強制切過去玩家 = false;

    void Start()
    {
        /*
        if (不可重複 != null)
        {
            Destroy(gameObject);
            return;
        }
        不可重複 = this;

        DontDestroyOnLoad(this);
    */
    }

    void Update()
    {

        尋找玩家();
        

        if (!玩家控制.切換使用敵人攝影機)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -6.5f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }

        else if (玩家控制.切換使用敵人攝影機)
        {
            Vector3 newPos1 = new Vector3(target1.position.x, target1.position.y + yOffset, -6.5f);
            transform.position = Vector3.Slerp(transform.position, newPos1, FollowSpeed * Time.deltaTime);
        }

    }
    void 尋找玩家()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //target = GameObject.Find("程式整合玩家").GetComponent<Transform>();
            //target = GameObject.Find("玩家身上擺放攝影機").GetComponent<Transform>();
        }

        if (target1 == null)
        {
            target1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //target1 = GameObject.Find("暫時沒有心靈控制").GetComponent<Transform>();
            //target1 = GameObject.Find("敵人身上擺放攝影機").GetComponent<Transform>();
        }
    }
}
