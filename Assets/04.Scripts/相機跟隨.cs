using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 相機跟隨 : MonoBehaviour
{
    public Transform 玩家;
    public float 順滑速率 = 1;

    // Start is called before the first frame update
    void Start()
    {
        //玩家 = GameObject.FindGameObjectWithTag("手臂").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(玩家 != null) 
        {
            if(transform.position != 玩家.position)
            {
                Vector3 玩家Pos = 玩家.position;
                transform.position = Vector3.Lerp(transform.position, 玩家Pos, 順滑速率);
            }
        }
    }


    void Update()
    {
        
    }
}
