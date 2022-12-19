using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodspray_Effect : MonoBehaviour
{
    public static Bloodspray_Effect 北;

    public int 糛﹀计 = 0;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        北 = this;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        糛﹀计 = PlayerHealth1.BloodI;
    }

    public void 繦诀铬﹀礶()
    {
        //anim.Play("诀");
        switch (糛﹀计)
        {
            case 1: // QUIT
                anim.Play("陪﹀1");
                break;

            case 2: //CLEAR
                anim.Play("陪﹀2");
                break;

            case 3: //CLEAR
                anim.Play("陪﹀3");
                break;

            default:

                break;
        }
    }
}
