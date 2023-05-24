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
    [Header("只要生命值模式")]//不包含布娃娃系統跟...給孢子怪用的
    public bool onlyHealth = false;

    [Header("孢子怪模式")]
    public bool sporeMode = false;//未編輯

    [Header("錄影殭屍模式")]
    public bool recordZombieMode = false;

    [Space(5)]
    [Header("攻擊")]
    public int attackDamage = 20;//攻擊傷害
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;//攻擊遮罩
    
    [Space(5)]
    [Header("攻擊位移")]
    private Vector2 _target;//移動終點目標
    public float attackSpeed = 0.3f;//移動速度
    public bool attackMove = false;

    Rigidbody2D rb;
    private float attackMoveDistance = 0.5f;

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
    [SerializeField] private Collider2D _collider;
    [SerializeField] private List<Collider2D> _colliders;
    [SerializeField] private List<HingeJoint2D> _joints;
    [SerializeField] private List<Rigidbody2D> _rbs;
    [SerializeField] private List<LimbSolver2D> _solvers;
    [SerializeField] private List<CCDSolver2D> _CCDsolvers;

    [Space(5)]
    [Header("開始直接Ragdoll")]
    public bool startRagdoll = false;

    void Start()
    {
        if(startRagdoll)
        {
            Invoke("Die", 0.01f);
        }

        if(!onlyHealth)
        {
            if(!startRagdoll)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            rb = gameObject.GetComponent<Rigidbody2D>();
            ToggleRagdoll(false);//開始時關閉布娃娃系統
        }
    }

    void Update()
    {
        if(attackMove)
        {
            JumpAttackToTarget2();
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
        //_target = new Vector2(player.position.x, rb.position.y);//找到玩家位置

        //attackMoveDistance = 0.02f;//初始每次位移距離

        //InvokeRepeating("JumpAttackToTarget", 0, 0.02f);//每0.01秒執行一次

        attackMove = true;
    }

    //移動到攻擊目標點
    public void JumpAttackToTarget()
    {
        //更改成新的位置
        Vector2 newPos = Vector2.MoveTowards(rb.position, _target, attackMoveDistance);
        rb.MovePosition(newPos);

        attackMoveDistance += 0.005f;//每次逐漸增加移動距離

        //每次最大移動距離限制
        if (attackMoveDistance >= 0.3f)
        {
            attackMoveDistance = 0.3f;
            Debug.Log("距離限制");
            //CancelInvoke("JumpAttackToTarget");
            //Debug.Log("cancelInvoke");
        }
    }

    // 在每幀中以指定速度移動到目標位置
    public void JumpAttackToTarget2()
    {
        //當前位置
        Vector2 currentPosition = transform.position;
        
        //怪物與玩家距離
        float playerDistance = Mathf.Abs(transform.position.x - player.position.x);
        //需要位移量
        float xMoveOffset;

        //如果怪物離玩家很近，會位移到可以咬到玩家的位置。
        if (playerDistance <= attackOffset.x)
        {
            if(isFlipped)
            {
                xMoveOffset = attackOffset.x + playerDistance;
            }
            else
            {
                xMoveOffset = attackOffset.x - playerDistance;
            }
        }
        else
        {
            xMoveOffset = 0;
        }

        //目標位置
        Vector2 targetPosition = new Vector2(player.position.x + xMoveOffset, rb.position.y);

        float maxDistanceDelta = attackSpeed * Time.deltaTime;
        Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, maxDistanceDelta);
        transform.position = newPosition;
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
        attackMove = false;

        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }

    //Ragdoll切換
    public void ToggleRagdoll(bool ragdollOn) 
    {
        _anim.enabled = !ragdollOn;
        _collider.enabled = !ragdollOn;

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
            if (Spore_Boos_random.無敵)
            {
                Boss.Hp -= 0;
            }
            if (!Spore_Boos_random.無敵)
            {
                Boss.Hp -= damage;
            }
            
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
}