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

    private void Start()
    {
        originalX = transform.position.x;

        // ��� MonsterRespawnPoint �����
        //respawnPoint = GetComponent<MonsterRespawnPoint>();

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

        if(��q.health <= 0)
        {
            detectPlayer = false;
            animator.SetBool("IsOpen", true);
        }
    }


    // �����I���i�J����k
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && detectPlayer)
        {
            // ���a�I���쪫��A����������ާ@
            Debug.Log("���a�I���쪫��I");
            // �b�o�̰����B�~���B�z

            // Ĳ�o�Ǫ��ͦ�
            respawnPoint.StartSpawn();

            // �����
            detectPlayer = false;

            // �����ʵe���A���}��
            animator.SetBool("IsOpen", true);
        }
    }

    // ø�s���ʽd�򪺥i���ƪ��
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(distance, transform.localScale.y, 0));
    }

    // ���a�����}�a���骺��k
    public void DestroyObject()
    {
        // ��������a�I��
        detectPlayer = false;
    }
}
