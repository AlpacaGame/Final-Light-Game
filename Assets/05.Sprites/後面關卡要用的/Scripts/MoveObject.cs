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


    public Light targetLight;
    public Color startColor;
    public Color endColor;
    public float colorChangeDuration = 1f;
    public float colorChangeDelay = 0f;

    private float currentLerpTime;
    private bool isColorChanging = false;

    private void Start()
    {
        originalX = transform.position.x;

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

        if (血量.health <= 0 && detectPlayer)
        {
            detectPlayer = false;
            animator.SetBool("IsOpen", true);
            SoundManager.instance.S_ExplosionSource();
            //ChangeLightColor();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && detectPlayer)
        {
            Debug.Log("玩家碰撞到物體！");
            detectPlayer = false;
            animator.SetBool("IsOpen", true);
            ChangeLightColor();
            respawnPoint.StartSpawn();
            SoundManager.instance.S_ExplosionSource();
            SoundManager.instance.AlarmSource();
        }
    }

    private void ChangeLightColor()
    {
        StartCoroutine(StartColorChangeDelay());
    }

    private IEnumerator StartColorChangeDelay()
    {
        yield return new WaitForSeconds(colorChangeDelay);

        // 開始顏色變換
        isColorChanging = true;
        currentLerpTime = 0f;

        // 偵測玩家攻擊破壞物體
        DestroyObject();
    }

    private void DestroyObject()
    {
        // 停止偵測玩家碰撞
        detectPlayer = false;
    }

    private void LateUpdate()
    {
        // 檢查是否正在進行顏色變換
        if (isColorChanging)
        {
            currentLerpTime += Time.deltaTime;
            float t = currentLerpTime / colorChangeDuration;
            targetLight.color = Color.Lerp(startColor, endColor, t);

            if (t >= 1.0f)
            {
                isColorChanging = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(distance, transform.localScale.y, 0));
    }
}
