using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlNeedGreenKey : MonoBehaviour
{

    public int index;
     

    public Image black;
    public Animator anim;

    public bool 需要鑰匙開關;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && 需要鑰匙開關)
        {
            StartCoroutine(Fading());
            //玩家控制.綠鑰匙 -= 1;
        }
    }

    void OnTriggerEnter2D(Collider2D Fade)
    {
        if (Fade.CompareTag("Player"))
        {
            需要鑰匙開關 = true;
        }

    }

    void OnTriggerExit2D(Collider2D Fade)
    {
        if (Fade.CompareTag("Player"))
        {
            需要鑰匙開關 = false;
        }
    }

    IEnumerator  Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }
}
