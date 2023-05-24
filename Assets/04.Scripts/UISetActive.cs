using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetActive : MonoBehaviour
{
    public GameObject ゴ秨UI;

    public bool 礚兵ン, 具珺簀狵, 干﹀;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(礚兵ン)
        {
            if (GameManager.UI秨闽)
            {
                ゴ秨UI.SetActive(true);
            }
            else if (!GameManager.UI秨闽)
            {
                ゴ秨UI.SetActive(false);
            }
        }    
        
        if (具珺簀狵)
        {
            if (GameManager.局Τも簀 || GameManager.局Τ˙簀)
            {
                if (GameManager.UI秨闽)
                {
                    ゴ秨UI.SetActive(true);
                }
                else if (!GameManager.UI秨闽)
                {
                    ゴ秨UI.SetActive(false);
                }
            }

            if (!GameManager.局Τも簀 && !GameManager.局Τ˙簀)
            {
                ゴ秨UI.SetActive(false);
            }
        }

        if (干﹀)
        {
            if (GameManager.局Τ干﹀)
            {
                if (GameManager.UI秨闽)
                {
                    ゴ秨UI.SetActive(true);
                }
                else if (!GameManager.UI秨闽)
                {
                    ゴ秨UI.SetActive(false);
                }
            }

            if (!GameManager.局Τ干﹀)
            {
                ゴ秨UI.SetActive(false);
            }
            
        }

    }
}
