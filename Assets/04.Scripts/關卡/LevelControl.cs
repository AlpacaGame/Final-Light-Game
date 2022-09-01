using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

    public int index;
     

    public Image black;
    public Animator anim;

    public bool 直接開門開關;

    //public bool 提示;
    public GameObject 亮光;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        black = GameObject.Find("屏幕黑幕").GetComponent<Image>();
        anim = GameObject.Find("屏幕黑幕").GetComponent<Animator>();
        /*
        if (black == null)
        {
            
        }
        if (anim == null)
        {
            
        }
        */
        if (Input.GetKey(KeyCode.E) && 直接開門開關)
        {
            StartCoroutine(Fading());
        }
    }

    void OnTriggerEnter2D(Collider2D Fade)
    {
        if (Fade.CompareTag("Player"))
        {
            直接開門開關 = true;
            亮光.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D Fade)
    {
        if (Fade.CompareTag("Player"))
        {
            直接開門開關 = false;
            亮光.SetActive(false);
        }
    }

    IEnumerator  Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}
