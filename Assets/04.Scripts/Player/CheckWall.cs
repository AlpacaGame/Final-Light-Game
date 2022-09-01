using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Check)
    {
        if (Check.CompareTag("Player"))
        {
            PlayerSlide.防撞牆彈回去 = true;
        }

    }

    void OnTriggerExit2D(Collider2D Check)
    {
        if (Check.CompareTag("Player"))
        {
            PlayerSlide.防撞牆彈回去 = false;
        }
    }
}
