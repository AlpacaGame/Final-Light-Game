using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D AttackBox)
    {
        if (AttackBox.gameObject.tag == "Player")
        {
            敵人health.敵人可攻擊 = true;
            Enemy_Zombie.敵人可攻擊 = true;
        }
    }

    void OnTriggerExit2D(Collider2D AttackBox)
    {
        if (AttackBox.gameObject.tag == "Player")
        {
            敵人health.敵人可攻擊 = false;
            Enemy_Zombie.敵人可攻擊 = false;
        }
    }

    
}
