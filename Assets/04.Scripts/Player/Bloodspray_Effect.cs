using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodspray_Effect : MonoBehaviour
{
    public static Bloodspray_Effect �D��;

    public int �Q��Ʀr = 0;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        �D�� = this;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        �Q��Ʀr = PlayerHealth1.BloodI;
    }

    public void �H������e��()
    {
        //anim.Play("�ݾ�");
        switch (�Q��Ʀr)
        {
            case 1: // QUIT
                anim.Play("���1");
                break;

            case 2: //CLEAR
                anim.Play("���2");
                break;

            case 3: //CLEAR
                anim.Play("���3");
                break;

            default:

                break;
        }
    }
}
