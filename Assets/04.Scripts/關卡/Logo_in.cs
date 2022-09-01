using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo_in : MonoBehaviour
{
    public GameObject 另一個Logo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void 另一個Logo開啟()
    {
        另一個Logo.SetActive(true);
    }

    public void 跑完Logo進主選單()
    {
        SceneManager.LoadScene(1);
    }
}
