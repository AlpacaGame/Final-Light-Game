using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Player : MonoBehaviour
{
    [Header("���a����")]
    public float energy = 100;//���a��O
    public float breatheEnergy = 50;//�ݮ���O��
    public float inputX = 0;//���k���ʭ�
    public float walkSpeed = 1.4f;//�����t��
    public float runSpeed = 10;//�]�B�t��
    public float runEnergyDecrease = 0.5f;//�]�B��O����
    public float walkEnergyIncrease = 0f;//������O�W�[
    public float idleEnergyIncrease = 1f;//�ݾ���O�W�[
    public bool slide = false;
    public bool breath = false;
    public float playerSpeed = 0;
    public float playerMaxSpeed = 5;

    [Header("�ͩR��")]
    public int health = 100;

    [Space(5)]
    [Header("Ragdoll�����ݭn������")]
    [SerializeField] private Animator _anim;
    [SerializeField] private List<Collider2D> _colliders;
    [SerializeField] private List<HingeJoint2D> _joints;
    [SerializeField] private List<Rigidbody2D> _rbs;
    [SerializeField] private List<LimbSolver2D> _solvers;

    [Header("��������")]
    private Rigidbody2D rg;
    private Animator anim;

    void Start()
    {
        ToggleRagdoll(false);//�}�l�������������t��

        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    //���a����
    public void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");

        if(health > 0)
        {
            if (inputX != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) && energy > 50)//���UShift�� & ��O����0
                {
                    Run();
                    anim.SetBool("isRun", true);
                }
                else if (Input.GetKey(KeyCode.LeftShift) && energy > 0)//���UShift�� & ��O����0
                {
                    Run();
                    anim.SetBool("isFastWalk", true);
                }
                else
                {
                    Walk();
                    anim.SetBool("isWalk", true);
                    anim.SetBool("isFastWalk", false);
                }
            }
            else
            {
                Idle();
                anim.SetBool("isWalk", false);
                anim.SetBool("isRun", false);
            }
        }
    }

    //�ݾ�
    public void Idle()
    {
        //anim.Play("Idle");
        energy += idleEnergyIncrease;//��q�W�[
    }

    //����
    public void Walk()
    {
        rg.velocity = new Vector2(inputX * walkSpeed, rg.velocity.y);
        //anim.Play("Walk");
        energy += walkEnergyIncrease;//��q�W�[
    }

    //�]�B
    public void Run()
    {
        rg.velocity = new Vector2(inputX * runSpeed, rg.velocity.y);
        //anim.Play("Run");
        energy -= runEnergyDecrease;//��q����

        //�ݮ��n
        if (energy <= breatheEnergy && !breath)
        {
            breath = true;
            SoundManager.instance.PantSource();
            Invoke("BreatheTime", 5);
        }
    }

    //�ݮ��n���j
    public void BreatheTime()
    {
        breath = false;
    }

    //Ragdoll����
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
    }

    //�����ˮ`
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    //���`
    public void Die()
    {
        ToggleRagdoll(true);
    }
}
