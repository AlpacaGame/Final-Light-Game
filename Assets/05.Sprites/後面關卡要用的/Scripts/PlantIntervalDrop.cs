using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIntervalDrop : MonoBehaviour
{
    public Animator[] animators;        // �x�s�n���}���ʵe��
    public float interval = 1f;         // ���j�ɶ�
    public float delay = 0f;            // ����ɶ��]�}�l�e�����ݮɶ��^

    private bool hasTriggered = false;  // �O�_Ĳ�o�L

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

        // �s�򥴶}�ʵe��
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
