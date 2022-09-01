using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadomAmmoFX : MonoBehaviour
{
    private Rigidbody2D rigidbody;


    public Vector2 startspeed;
    public int 旋轉亂數;
    public int 速度;
    public float 時間;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * startspeed.x + transform.up * startspeed.y;
    }

    // Update is called once per frame
    void Update()
    {

        時間 += Time.time;
        if (時間>=1)
        {
            時間 = 0;
            旋轉亂數--;
        }
        if(旋轉亂數 <=0)
        {
            旋轉亂數 = 0;
        }
        rigidbody.rotation += 旋轉亂數 * Time.deltaTime;
        
    }

    void OnTriggerEnter2D(Collider2D 碰牆) 
    {
        if(碰牆.CompareTag("floor"))
        {
            //rigidbody.simulated = false;
            Destroy(gameObject, 4f);
        }
    }
}
