using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Enemy : MonoBehaviour
{
    [Header("生命值")]
    public int health = 100;
    //public GameObject deathEffect;

    //[Space(20)]
    [Header("Ragdoll切換需要的物件")]
    [SerializeField] private Animator _anim;
    [SerializeField] private List<Collider2D> _colliders;
    [SerializeField] private List<HingeJoint2D> _joints;
    [SerializeField] private List<Rigidbody2D> _rbs;
    [SerializeField] private List<LimbSolver2D> _solvers;
    [SerializeField] private List<CCDSolver2D> _CCDsolvers;

    void Start()
    {
        ToggleRagdoll(false);
    }

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

    public void Die()
    {
        ToggleRagdoll(true);
        Invoke("Disappear", 5);
    }

    public void Disappear()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
