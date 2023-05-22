using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    private Transform targetPosition; // �ؼЦ�m�� Transform �ե�

    private void Update()
    {
        // ���򰻴� "���a�����I" ���s�b�ç��
        if (targetPosition == null)
        {
            GameObject respawnPoint = GameObject.Find("���a�����I");
            if (respawnPoint != null)
            {
                targetPosition = respawnPoint.transform;
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Teleport();
        }
    }

    public void Teleport()
    {
        // �ˬd�ؼЦ�m�O�_�s�b
        if (targetPosition != null)
        {
            // �N���骺��m�]�m���ؼЦ�m����m
            transform.position = targetPosition.position;
        }
        else
        {
            Debug.LogWarning("�ؼЦ�m���]�w�I");
        }
    }
}
