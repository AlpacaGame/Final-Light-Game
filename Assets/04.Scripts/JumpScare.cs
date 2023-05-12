using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("Des", 0.5f);
        }
    }

    public void Des()
    {
        Destroy(this.gameObject);
    }
}
