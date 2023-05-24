using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnTrigger : MonoBehaviour
{
    //private ShakeEffect shakeEffect; // �_�ʮĪG�}�����Ѧ�
    private bool hasTriggered = false; // �O�_�wĲ�o�_�ʪ��лx��

    private void Start()
    {
        //shakeEffect = GetComponent<ShakeEffect>(); // ���o�_�ʮĪG�}�����Ѧ�
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player")) // �ˬd�O�_�wĲ�o�B�I������O�_�O���a
        {
            //shakeEffect.Shake(1, 0.5f, 0.1f); // �եξ_�ʵ{���A�Ѽƥi�ھڻݨD�ۦ�վ�
            ScreenShake.instance.StartShake(0.5f, 0.2f);
            hasTriggered = true; // �NĲ�o�лx��]���wĲ�o
        }
    }
}
