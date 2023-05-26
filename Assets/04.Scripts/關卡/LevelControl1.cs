using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl1 : MonoBehaviour
{
    //public static LevelControl1 門開關物件控制;
    public int index;
     

    public Image black;
    public Animator anim;

    public bool 直接開門開關;

    //public bool 提示;
    public GameObject 亮光;

    private Animator anim_Door;
    public Animator anim互動;

    public static bool 間接開門;

    public bool 另一種感應物件;
    public bool 擁有ID卡才能開,ID卡;

    // Start is called before the first frame update
    void Start()
    {
        anim_Door = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        black = GameObject.Find("屏幕黑幕").GetComponent<Image>();
        anim = GameObject.Find("屏幕黑幕").GetComponent<Animator>();

        if (Input.GetKey(KeyCode.E) && 直接開門開關 && Player.health >= 0)
        {
            StartCoroutine(Fading());
        }
        if (另一種感應物件 && GameManager.擁有門禁卡)
        {
            由其他物件來開門();
        }

    }

    void 由其他物件來開門()
    {
        if(間接開門)
        {
            anim_Door.SetBool("門開", true);
            anim互動.SetBool("門開", true);
            直接開門開關 = true;
            亮光.SetActive(true);
        }
        else if (!間接開門)
        {
            anim_Door.SetBool("門開", false);
            anim互動.SetBool("門開", false);
            直接開門開關 = false;
            亮光.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D Fade)
    {
        if (Fade.CompareTag("Player") && Player.health >= 0)
        {
            anim_Door.SetBool("門開", true);
            anim互動.SetBool("門開", true);
            直接開門開關 = true;
            亮光.SetActive(true);
        }

    }

    void OnTriggerExit2D(Collider2D Fade)
    {
        if (Fade.CompareTag("Player"))
        {
            anim_Door.SetBool("門開", false);
            anim互動.SetBool("門開", false);
            直接開門開關 = false;
            亮光.SetActive(false);
        }
    }

    IEnumerator  Fading()
    {
        anim.SetBool("Fade", true);
        直接開門開關 = false;
        間接開門 = false;
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}
