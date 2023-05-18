using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public GameObject GlassDoor;
    public Animator anim;
    private float t;
    public float FieldOfViewMax = 120;
    public static bool StartBossFight = false;
    public GameObject BossHealthBar;

    void Start()
    {
        anim = GlassDoor.GetComponent<Animator>();
        StartBossFight = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("Open");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.transform.position.x < transform.position.x)
        {
            anim.Play("Close");
            t = 0;
            InvokeRepeating("SetCamFieldOfViewTo110", 1, 0.01f);

            StartBossFight = true;
            GameObject.Find("MainCamera").GetComponent<ScreenShake>().StartShake(1.5f, 0.18f);//螢幕震動4 .5
            SoundManager.instance.EnemyBoos_AttackSource2();//怒吼音效
            SoundManager.instance.Boosfight_SourceMusic(); // 切換魔王背景音樂

            BossHealthBar.SetActive(true);

            Invoke("後來關掉", 5f);
        }
    }

    public void SetCamFieldOfViewTo110()
    {
        Camera.main.fieldOfView = Mathf.Lerp(90, FieldOfViewMax, t);
        t += 0.01f;
    }

    void 後來關掉()
    {
        Destroy(gameObject);
    }
}