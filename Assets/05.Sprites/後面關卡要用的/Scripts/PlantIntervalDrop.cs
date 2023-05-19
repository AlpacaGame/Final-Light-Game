using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIntervalDrop : MonoBehaviour
{
    public Animator[] animators;        // 儲存要打開的動畫器
    public float interval = 1f;         // 間隔時間
    public float delay = 0f;            // 延遲時間（開始前的等待時間）

    private bool hasTriggered = false;  // 是否觸發過

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            StartCoroutine(PlayAnimators());
            hasTriggered = true;
        }
    }

    private IEnumerator PlayAnimators()
    {
        yield return new WaitForSeconds(delay);

        // 連續打開動畫器
        for (int i = 0; i < animators.Length; i++)
        {
            interval -= 0.05f;
            animators[i].SetBool("IsOpen", true);
            yield return new WaitForSeconds(interval);
            ScreenShake.instance.StartShake(0.5f, 1f);
            SoundManager.instance.DropdSource();
        }
    }
}
