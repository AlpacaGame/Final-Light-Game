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


    public MonsterRespawnPoint respawnPoint; // �ޥ� MonsterRespawnPoint �����
    public Animator animator; // �ʵe���

    public Enemy ��q;


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

        // ��� Animator �����
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ����饪�k����
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

        if (��q.health <= 0 && detectPlayer)
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
            Debug.Log("���a�I���쪫��I");
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

        // �}�l�C���ܴ�
        isColorChanging = true;
        currentLerpTime = 0f;

        // �������a�����}�a����
        DestroyObject();
    }

    private void DestroyObject()
    {
        // ��������a�I��
        detectPlayer = false;
    }

    private void LateUpdate()
    {
        // �ˬd�O�_���b�i���C���ܴ�
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
