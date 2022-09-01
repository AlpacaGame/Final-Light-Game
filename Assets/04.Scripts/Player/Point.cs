using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    public Image hp;
    public Image hurt;

    public float harm = 0.1f;
    public float regain = 0.1f;
    public float speed = 0.1f;

    float starttime;
    
    void Start()
    {
        hurt.fillAmount = hp.fillAmount = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            hp.fillAmount -= harm;

            starttime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            hp.fillAmount += regain;
            starttime = Time.time;
        }
        

        if (hurt.fillAmount != hp.fillAmount)
        {
            hurt.fillAmount = Mathf.Lerp(hurt.fillAmount, hp.fillAmount, (Time.time - starttime + 0.5f) * speed);
        }
        
    }
}
