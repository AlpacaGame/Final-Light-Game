using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetActive : MonoBehaviour
{
    public GameObject ���}UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.UI�}��)
        {
            ���}UI.SetActive(true);
        }
        else if(!GameManager.UI�}��)
        {
            ���}UI.SetActive(false);
        }

    }
}
