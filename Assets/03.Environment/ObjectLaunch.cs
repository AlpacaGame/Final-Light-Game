using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLaunch : MonoBehaviour
{
    public float launchForce = 10f;     // �I�[���O�q�j�p
    public Vector2 launchDirection;     // �I�[���O�q��V
    public float rotationSpeed = 100f;  // ���઺��l�t��
    public float rotationDecayRate = 10f;  // ����t�װI��v

    private Rigidbody2D rb;
    private float currentRotationSpeed;  // ��e����t��

    public void Launch()
    {
        rb = GetComponent<Rigidbody2D>();
        ApplyLaunchForce();
        currentRotationSpeed = rotationSpeed;
    }

    private void Update()
    {
        ApplyRotation();
        DecayRotationSpeed();
    }

    private void ApplyLaunchForce()
    {
        // ���W�ƬI�[�O����V�V�q
        launchDirection.Normalize();

        // �I�[�O
        Vector2 force = launchDirection * launchForce;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void ApplyRotation()
    {
        // �p�����q
        float rotationAmount = currentRotationSpeed * Time.deltaTime;

        // ¶ Z �b�i�涶�ɰw����
        transform.Rotate(0f, 0f, rotationAmount);
    }

    private void DecayRotationSpeed()
    {
        // �ھڰI��v�v����p����t��
        currentRotationSpeed -= rotationDecayRate * Time.deltaTime;

        // �������t�פ��|�ܬ��t��
        currentRotationSpeed = Mathf.Max(currentRotationSpeed, 0f);
    }
}
