using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Ammo : MonoBehaviour
{



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
            Gun_fire.彈匣數量+=1;
            Destroy(gameObject);
        }
    }
}
