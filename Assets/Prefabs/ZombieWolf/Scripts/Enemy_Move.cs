using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public float playerY_Offset = -0.98f;

    Transform player;
    Rigidbody2D rb;
    //EnemyLookAtPlayer enemyLookAtPlayer;
    Enemy enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    [Space(5)]
    [Header("使用新角色Y值定位點")]//怪物追新角色不需要Yoffset，不然會沉入地下
    public bool NoOffsetY = false;

    [Space(5)]
    [Header("玩家進入範圍才會追逐玩家")]
    public float WalkToPlayerDistance = 10;

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

        if(Vector2.Distance(player.position, rb.position) < WalkToPlayerDistance)
        {
            if (NoOffsetY)//給新角色用
            {
                Vector2 target = new Vector2(player.position.x, rb.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }
            else
            {
                Vector2 target = new Vector2(player.position.x, player.position.y + playerY_Offset);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
            }
        }

        if(Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
