using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spore_Damage : MonoBehaviour
{

    public int 胞子給予傷害 = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D DamagePlay)
    {
        if (DamagePlay.gameObject.tag == "Player")
        {
            PlayerHealth.玩家生命 -= 胞子給予傷害;
        }
    }
}
