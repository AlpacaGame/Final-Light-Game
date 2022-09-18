using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public GameObject GlassDoor;
    public Animator anim;
    private float t;
    public float FieldOfViewMax = 120;

    void Start()
    {
        anim = GlassDoor.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("Open");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.transform.position.x < transform.position.x)
        {
            anim.Play("Close");
            t = 0;
            InvokeRepeating("SetCamFieldOfViewTo110", 1, 0.01f);
        }
    }

    public void SetCamFieldOfViewTo110()
    {
        Camera.main.fieldOfView = Mathf.Lerp(90, FieldOfViewMax, t);
        t += 0.01f;
    }
}