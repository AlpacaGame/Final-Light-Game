using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject 玩家;
    public Transform 重生點;

    public static bool 死亡重生 = false;

    // Start is called before the first frame update
    void Start()
    {
        重生();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void 重生()
    {
        if(死亡重生)
        {
            Vector3 重生點pos = this.transform.position + new Vector3(0, 0, 0);
            Instantiate(玩家, 重生點pos, 重生點.transform.rotation);
            死亡重生 = false;
        }
    }
}
