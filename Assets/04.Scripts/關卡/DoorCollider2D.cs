using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Fade)
    {
        if (Fade.CompareTag("Player"))
        {
            LevelControl1.間接開門 = true;
        }

    }

    void OnTriggerExit2D(Collider2D Fade)
    {
        if (Fade.CompareTag("Player"))
        {
            LevelControl1.間接開門 = false;
        }
    }
}
