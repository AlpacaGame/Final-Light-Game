using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineDamage : MonoBehaviour
{
    public int attackDamage = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ÃÃ½¯¶Ë®`");
            //GetComponent<Player>().TakeDamage(attackDamage);
            Player.¤£¥i­«½Æ.TakeDamage(attackDamage);
        }
    }
}
