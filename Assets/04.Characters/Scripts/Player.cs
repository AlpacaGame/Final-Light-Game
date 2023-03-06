using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Player : MonoBehaviour
{
    [Header("���a���V")]
    public Camera Orthographic;//������v��
    public static int direction = 1;//���k���V(�V�k=1�A�V��=-1)

    [Header("���a��O��")]
    public float energy = 100;//���a��O
    public float breatheEnergy = 50;//�ݮ���O��
    public float runEnergyDecrease = 5f;//�]�B��O����
    public float slideEnergyDecrease = 50;//�Ʀ���O����
    public float walkEnergyIncrease = 0f;//������O�W�[
    public float idleEnergyIncrease = 1f;//�ݾ���O�W�[

    [Header("���a����")]
    public float inputX = 0;//���k���ʭ�
    public float walkSpeed = 1.4f;//�����t��
    public float runSpeed = 10;//�]�B�t��
    public float slideSpeed = 20;//�Ʀ�t��

    [Header("���a�ʵe")]
    public bool sliding = false;//�Ʀ椤
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
        PlayerMove();
    }

    private void FixedUpdate()
    {
        
        PlayerDirection();
    }

    //���a���V �������нվ㨤�⥪�k���V
    public void PlayerDirection()
    {
        Vector3 difference = Orthographic.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (rotationZ < -90 || rotationZ > 90)
        {
            direction = -1;
            transform.localScale = new Vector3(direction, 1, 1);
        }

        else if (rotationZ > -90 || rotationZ < 90)
        {
            direction = 1;
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

    //���a����
    public void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");

        if(health > 0)
        {
            if(Input.GetKeyDown(KeyCode.C) && energy > slideEnergyDecrease && !sliding)
            {
                Slide();
            }
            else if (inputX != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) && energy > runEnergyDecrease)
                {
                    Run();
                }
                else
                {
                    Walk();
                }
            }
            else
            {
                Idle();
            }
        }

        if(energy >= 100)
        {
            energy = 100;
        }
    }

    //�ݾ�
    public void Idle()
    {
        energy += idleEnergyIncrease;//��q�W�[
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", false);
    }

    //����
    public void Walk()
    {
        rg.velocity = new Vector2(inputX * walkSpeed, rg.velocity.y);
        energy += walkEnergyIncrease;//��q�W�[

        anim.SetBool("isWalking", true);
        anim.SetBool("isRunning", false);
    }

    //�]�B
    public void Run()
    {
        rg.velocity = new Vector2(inputX * runSpeed, rg.velocity.y);
        //anim.Play("Run");
        energy -= runEnergyDecrease;//��q����

        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", true);

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

    //�Ʀ�
    public void Slide()
    {
        sliding = true;
        anim.SetBool("isSliding", true);
        energy -= slideEnergyDecrease;
        rg.velocity = new Vector2(direction * slideSpeed, rg.velocity.y);
    }

    //�Ʀ浲��
    public void SlideOver()
    {
        sliding = false;
        anim.SetBool("isSliding", false);
        rg.velocity = new Vector2(0, rg.velocity.y);
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
