using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Ammo : MonoBehaviour
{
    public bool 手槍彈匣, 步槍彈匣;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Pick)
    {
        if (Pick.CompareTag("Player"))
        {
            if(手槍彈匣)
            {
                Gun_fire.手槍彈匣數量 += 1;
                Destroy(gameObject);
            }

            if (步槍彈匣)
            {
                Gun_fire.步槍彈匣數量 += 1;
                Destroy(gameObject);
            }
        }
    }
}
