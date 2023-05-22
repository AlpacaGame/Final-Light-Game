using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControl2 : MonoBehaviour
{
    public bool 無條件進入;
    public bool 有條件進入;
    public bool 擁有ID卡;

    public Image 黑幕;
    public Animator 動畫控制器;

    public GameObject 亮光;

    private Animator anim_Door;
    public Animator anim互動;

    public string 無條件進入場景名稱;
    public string 有條件進入場景名稱;

    private bool 玩家進入範圍;

    void Start()
    {
        anim_Door = GetComponent<Animator>();

    }

    void Update()
    {
        黑幕 = GameObject.Find("屏幕黑幕").GetComponent<Image>();
        動畫控制器 = GameObject.Find("屏幕黑幕").GetComponent<Animator>();

        if (擁有ID卡 && GameManager.擁有染血的ID卡)
        {
            有條件進入 = true;
        }

        if (無條件進入 && 玩家進入範圍 && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(淡出效果(無條件進入場景名稱));
        }

        if (有條件進入 && 玩家進入範圍 && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(淡出效果(有條件進入場景名稱));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && 擁有ID卡)
        {
            if(GameManager.擁有染血的ID卡)
            {
                玩家進入範圍 = true;
                anim_Door.SetBool("門開", true);
                anim互動.SetBool("門開", true);
                亮光.SetActive(true);
            }
                

        }

        if (other.CompareTag("Player") && !擁有ID卡)
        {
            玩家進入範圍 = true;
            anim_Door.SetBool("門開", true);
            anim互動.SetBool("門開", true);
            亮光.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            玩家進入範圍 = false;
            anim_Door.SetBool("門開", false);
            anim互動.SetBool("門開", false);
            亮光.SetActive(false);
        }
    }

    private IEnumerator 淡出效果(string 目標場景名稱)
    {
        if (黑幕 != null && 動畫控制器 != null)
        {
            動畫控制器.SetBool("Fade", true);
            yield return new WaitUntil(() => 黑幕.color.a == 1);

            SceneManager.LoadScene(目標場景名稱);

            玩家進入範圍 = false;

            動畫控制器.SetBool("Fade", false);
        }
    }

}


