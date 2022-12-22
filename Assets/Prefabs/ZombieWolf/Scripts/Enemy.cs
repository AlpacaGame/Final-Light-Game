using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Enemy : MonoBehaviour
{
    [Header("敵人面向玩家")]
    public Transform player;
    public bool isFlipped = false;

    [Space(5)]
    [Header("只要生命值模式")]
    public bool onlyHealth = false;

    [Space(5)]
    [Header("攻擊")]
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    Rigidbody2D rb;
    public float attackSpeed = 0.3f;
    private float attackMoveDistance = 0.5f;
    private Vector2 _target;
    public float PlayerY_Offset = -0.98f;

    [Space(5)]
    [Header("生命值")]
    public int health = 100;
    public float disappearTime = 5;
    public GameObject deathEffect;

    [Space(5)]
    [Header("與Boss主體生命值同步")]
    public bool BossHealthModel = false;
    public Spore_Boos Boss;

    [Space(5)]
    [Header("Ragdoll切換需要的物件")]
    [SerializeField] private Animator _anim;
    [SerializeField] private List<Collider2D> _colliders;
    [SerializeField] private List<HingeJoint2D> _joints;
    [SerializeField] private List<Rigidbody2D> _rbs;
    [SerializeField] private List<LimbSolver2D> _solvers;
    [SerializeField] private List<CCDSolver2D> _CCDsolvers;

    void Start()
    {
        if(!onlyHealth)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            rb = gameObject.GetComponent<Rigidbody2D>();
            ToggleRagdoll(false);
        }
    }

    //敵人面向玩家
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    //執行攻擊位移
    public void AttackMove()
    {
        _target = new Vector2(player.position.x, player.position.y + PlayerY_Offset);
        InvokeRepeating("JumpAttackToTarget", 0, 0.01f);
    }

    //移動到攻擊目標點
    public void JumpAttackToTarget()
    {
        attackMoveDistance = attackSpeed;
        Vector2 newPos = Vector2.MoveTowards(rb.position, _target, attackMoveDistance);
        rb.MovePosition(newPos);
        attackMoveDistance += attackSpeed;
        if (attackMoveDistance >= 10)
        {
            CancelInvoke("JumpAttackToTarget");
            Debug.Log("cancelInvoke");
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

    //玩家若在範圍內則給予傷害
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth1>().TakeDamage(attackDamage);
        }
    }

    //Ragdoll切換
    public void ToggleRagdoll(bool ragdollOn) 
    {
        _anim.enabled = !ragdollOn;

        foreach (var col in _colliders)
        {
            col.enabled = ragdollOn;
        }

        foreach (var joint in _joints)
        {
            joint.enabled = ragdollOn;
        }

        foreach (var rb in _rbs)
        {
            rb.simulated = ragdollOn;
        }

        foreach (var solver in _solvers)
        {
            solver.weight = ragdollOn ? 0 : 1;
        }

        foreach (var solver in _CCDsolvers)
        {
            //solver.weight = ragdollOn ? 0 : 1;
            solver.weight = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if(BossHealthModel)
        {
            Boss.Hp -= damage;
        }
        else
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }
    }

    //死亡
    public void Die()
    {
        if(!onlyHealth)
        {
            ToggleRagdoll(true);
            EnemySpawner.EnemyLeft -= 1;
        }
        Invoke("Disappear", disappearTime);
    }

    //消失
    public void Disappear()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}