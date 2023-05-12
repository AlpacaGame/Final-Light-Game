using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAmmoDamage : MonoBehaviour
{
    public int attackDamage = 10;

    public float disappearTime = 5;
    public GameObject deathEffect;
    public bool ���z,Ĳ�I;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ĳ�I && ���z)
        {
            Invoke("Disappear",0.5f);
            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�]�l�ˮ`");
            //GetComponent<Player>().TakeDamage(attackDamage);
            Player.���i����.TakeDamage(attackDamage);
            Ĳ�I = true;
        }
    }

    public void Disappear()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
