using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLaunch : MonoBehaviour
{
    public float launchForce = 10f;     // 施加的力量大小
    public Vector2 launchDirection;     // 施加的力量方向
    public float rotationSpeed = 100f;  // 旋轉的初始速度
    public float rotationDecayRate = 10f;  // 旋轉速度衰減率

    private Rigidbody2D rb;
    private float currentRotationSpeed;  // 當前旋轉速度

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
        // 正規化施加力的方向向量
        launchDirection.Normalize();

        // 施加力
        Vector2 force = launchDirection * launchForce;
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    private void ApplyRotation()
    {
        // 計算旋轉量
        float rotationAmount = currentRotationSpeed * Time.deltaTime;

        // 繞 Z 軸進行順時針旋轉
        transform.Rotate(0f, 0f, rotationAmount);
    }

    private void DecayRotationSpeed()
    {
        // 根據衰減率逐漸減小旋轉速度
        currentRotationSpeed -= rotationDecayRate * Time.deltaTime;

        // 限制旋轉速度不會變為負值
        currentRotationSpeed = Mathf.Max(currentRotationSpeed, 0f);
    }
}
