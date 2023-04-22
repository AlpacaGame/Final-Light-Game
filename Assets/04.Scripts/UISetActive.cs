using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetActive : MonoBehaviour
{
    public GameObject 打開UI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.UI開關)
        {
            打開UI.SetActive(true);
        }
        else if(!GameManager.UI開關)
        {
            打開UI.SetActive(false);
        }

    }
}
