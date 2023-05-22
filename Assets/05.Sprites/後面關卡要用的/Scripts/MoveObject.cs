using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 5.0f;

    private float originalX;
    private bool movingRight = true;
    private bool detectPlayer = true;

    public MonsterRespawnPoint respawnPoint; // 引用 MonsterRespawnPoint 的實例
    public Animator animator; // 動畫控制器

    public Enemy 血量;

    private void Start()
    {
        originalX = transform.position.x;

        // 獲取 MonsterRespawnPoint 的實例
        //respawnPoint = GetComponent<MonsterRespawnPoint>();

        // 獲取 Animator 的實例
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 控制物體左右移動
        if (movingRight && detectPlayer)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= originalX + distance)
            {
                movingRight = false;
            }
        }
        else if (!movingRight && detectPlayer)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= originalX)
            {
                movingRight = true;
            }
        }

        if(血量.health <= 0)
        {
            detectPlayer = false;
            animator.SetBool("IsOpen", true);
        }
    }


    // 偵測碰撞進入的方法
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && detectPlayer)
        {
            // 玩家碰撞到物體，執行相應的操作
            Debug.Log("玩家碰撞到物體！");
            // 在這裡執行額外的處理

            // 觸發怪物生成
            respawnPoint.StartSpawn();

            // 停止移動
            detectPlayer = false;

            // 切換動畫狀態為開啟
            animator.SetBool("IsOpen", true);
        }
    }

    // 繪製移動範圍的可視化表示
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(distance, transform.localScale.y, 0));
    }

    // 玩家攻擊破壞物體的方法
    public void DestroyObject()
    {
        // 停止偵測玩家碰撞
        detectPlayer = false;
    }
}
