using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack1 : MonoBehaviour
{
 
    public int attackDamage = 20;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    Transform player;
    Rigidbody2D rb;
    public float attackSpeed = 0.3f;
    private float attackMoveDistance = 0.5f;
    private Vector2 _target;

    public float PlayerY_Offset = -0.98f;
        
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    //執行攻擊位移
    public void AttackMove()
    {
        /*
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, attackMoveDistance);
        rb.MovePosition(newPos);
        */
        /*
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, attackMoveDistance);
        */
        //Vector2.Lerp(transform.position, player.position, attackMoveDistance);

        _target = new Vector2(player.position.x, player.position.y + PlayerY_Offset);
        InvokeRepeating("JumpAttackToTarget", 0, 0.01f);
    }

    //移動到攻擊目標點
    
    public void JumpAttackToTarget()
    {
        /*
        Vector2 newPos = Vector2.MoveTowards(rb.position, _target, attackMoveDistance);
        rb.MovePosition(newPos);

        Camera.main.fieldOfView = Mathf.Lerp(90, FieldOfViewMax, t);
        t += 0.01f;
        */
        attackMoveDistance = attackSpeed;
        Vector2 newPos = Vector2.MoveTowards(rb.position, _target, attackMoveDistance);
        rb.MovePosition(newPos);
        attackMoveDistance += attackSpeed;
        if(attackMoveDistance >= 10)
        {
            CancelInvoke("JumpAttackToTarget");
            Debug.Log("cancelInvoke");
        }
    }
    

    public void FixedUpdate()
    {

        //rb.AddForce(new Vector2(5f,0f));
    }

    //玩家若在範圍內則給予傷害
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth1>().TakeDamage(attackDamage);
        }
    }

    //繪製攻擊範圍
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

    void Update()
    {
        
    }


}
