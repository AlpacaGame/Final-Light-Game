using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDirection : MonoBehaviour
{
    public bool �ϦV�}�� = true;
    void Update()
    {
        if(�ϦV�}��)
        {
            if (GameManager.�֦��K�X��K�X)
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            if (!GameManager.�֦��K�X��K�X)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
        }
    }
}
