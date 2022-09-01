using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosAttack : MonoBehaviour
{

    private Rigidbody2D rg2D;
    public Vector2 startspeed;

    // Start is called before the first frame update
    void Start()
    {
        rg2D= GetComponent<Rigidbody2D>();
        rg2D.velocity = transform.right * startspeed.x + transform.up * startspeed.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
