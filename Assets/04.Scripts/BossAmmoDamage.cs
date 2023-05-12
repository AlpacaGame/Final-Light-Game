using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAmmoDamage : MonoBehaviour
{
    public int attackDamage = 10;

    public float disappearTime = 5;
    public GameObject deathEffect;
    public bool 自爆,觸碰;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(觸碰 && 自爆)
        {
            Invoke("Disappear",0.5f);
            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("包子傷害");
            //GetComponent<Player>().TakeDamage(attackDamage);
            Player.不可重複.TakeDamage(attackDamage);
            觸碰 = true;
        }
    }

    public void Disappear()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
