using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetActive : MonoBehaviour
{
    public GameObject 打開UI;

    public bool 無條件, 撿拾槍枝, 補血;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(無條件)
        {
            if (GameManager.UI開關)
            {
                打開UI.SetActive(true);
            }
            else if (!GameManager.UI開關)
            {
                打開UI.SetActive(false);
            }
        }    
        
        else if (撿拾槍枝 && GameManager.擁有手槍)
        {
            if (GameManager.UI開關)
            {
                打開UI.SetActive(true);
            }
            else if (!GameManager.UI開關)
            {
                打開UI.SetActive(false);
            }
        }

        else if (補血 && GameManager.擁有補血)
        {
            if (GameManager.UI開關)
            {
                打開UI.SetActive(true);
            }
            else if (!GameManager.UI開關)
            {
                打開UI.SetActive(false);
            }
        }

    }
}
