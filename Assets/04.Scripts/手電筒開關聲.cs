using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 手電筒開關聲 : MonoBehaviour
{
    public AudioClip 開音效;

    private bool 手電開啟;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && 手電開啟)
        {
            GetComponent<AudioSource>().PlayOneShot(開音效);
        }

        if (Input.GetMouseButtonDown(1) && 手電開啟)
        {
            GetComponent<AudioSource>().PlayOneShot(開音效);
        }
    }
}
