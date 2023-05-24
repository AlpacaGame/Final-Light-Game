using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackDistance = 3f;

    Transform player;
    Rigidbody2D rb;
    //EnemyLookAtPlayer enemyLookAtPlayer;
    Enemy enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    [Space(5)]
    [Header("���a�i�J�d��~�|�l�v���a")]
    public float WalkToPlayerDistance = 10;

    [Space(5)]
    [Header("�L�ͤ��Ҧ�")]
    public bool zombieWolfMode = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtPlayer();

        if(zombieWolfMode)//�L�ͤ��|�����a�@�q�Z��
        {
            if (Vector2.Distance(player.position, rb.position) < WalkToPlayerDistance)
            {
                if (Vector2.Distance(player.position, rb.position) <= attackDistance)
                {
                    animator.SetTrigger("Attack");
                }
                else
                {
                    Vector2 target = new Vector2(player.position.x, rb.position.y);
                    Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                    rb.MovePosition(newPos);
                }
            }
        }
        else
        {
            if (Vector2.Distance(player.position, rb.position) < WalkToPlayerDistance)
            {
                Vector2 target = new Vector2(player.position.x, rb.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);

                if (Vector2.Distance(player.position, rb.position) <= attackDistance)
                {
                    animator.SetTrigger("Attack");
                }
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
