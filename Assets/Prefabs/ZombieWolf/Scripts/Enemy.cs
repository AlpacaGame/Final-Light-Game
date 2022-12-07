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
    [Header("生命值")]
    public int health = 100;
    public int disappearTime = 5;
    //public GameObject deathEffect;

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
        player = GameObject.FindGameObjectWithTag("Player").transform;

        ToggleRagdoll(false);
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
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    //死亡
    public void Die()
    {
        ToggleRagdoll(true);
        Invoke("Disappear", disappearTime);
    }

    //消失
    public void Disappear()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
