using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Damage)
    {
        if (Damage.gameObject.tag == "Player")
        {
            PlayerHealth.玩家生命 -= 敵人health.給予攻擊傷害點;
            SoundManager.instance.Enemy_AttackSource();
        }
    }

}
