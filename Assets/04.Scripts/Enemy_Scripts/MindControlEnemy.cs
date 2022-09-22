using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControlEnemy : MonoBehaviour
{
    public bool 這關沒有心靈控制;
    public GameObject 自己,顯示頭上被控制;

    public float 走路速度 = 5f;
    public float inputX = 0.0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (這關沒有心靈控制)
        {
            自己.SetActive(false);
        }
        else if (!這關沒有心靈控制)
        {
            自己.SetActive(true);
        }
        操控殭屍心靈控制();
    }

    void 操控殭屍心靈控制()
    {
        if(玩家控制.切換使用敵人攝影機)
        {
            走路();
            //攻擊();
            顯示頭上被控制.SetActive(true);
        }

        else
        {
            顯示頭上被控制.SetActive(false);
        }
    }

    void 走路()
    {

        inputX = Input.GetAxis("Horizontal");
        Vector3 moveVelocity = Vector3.zero;
        


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        //transform.position += moveVelocity * 走路速度 * Time.deltaTime;
        rb.velocity = new Vector2(inputX * 走路速度 , rb.velocity.y);
    }
}
