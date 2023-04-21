using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorFollow : MonoBehaviour
{
    public float moveSpeed = 10f;

    public float distance;

    public bool ScaleChangeModel = false;
    public float miniScale = 1f;
    public float maxScale = 0.2f;
    public float scaleChange;

    public Camera Orthographic;

    [Space(5)]
    [Header("限制鼠標位置")]

    public bool CursorAreaModel = false;

    public float MinimumValueY = -0.75f;
    public float MaxmumValueY = 2.5f;

    public GameObject CursorManager;
    public GameObject Player;

    public float MinimumValueX = -3.5f;
    public float MaxmumValueX = 3.5f;

    [Space(5)]
    [Header("場景左右邊界限制鼠標位置")]
    public float[] SceneLeftValueX;
    public float[] SceneRightValueX;

    void Start()
    {
        CursorManager = transform.parent.gameObject;//以父物件作為限制鼠標X值參考
        Player = CursorManager.transform.parent.gameObject;

        SceneLeftValueX = new float[] { -30f, -9f, 1f, 0.5f, 7.5f, 36f, -19f, -1000f, -1000f, -1000f};//寫入場景的邊界
        SceneRightValueX = new float[] { 30f, 19f, 30f, 14f, 35f, 113.5f, 113.5f, 1000f, 1000f, 1000f};
    }

    void Update()
    {
        Vector2 cursorPos = Orthographic.ScreenToWorldPoint(Input.mousePosition);
        distance = Mathf.Abs(transform.position.x - cursorPos.x) + Mathf.Abs(transform.position.y - cursorPos.y);
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime * distance);
        if (ScaleChangeModel)
        {
            scaleChange = miniScale + distance * maxScale;
            transform.localScale = new Vector3(scaleChange, scaleChange, 1);
        }

        //限制鼠標位置

        if (CursorAreaModel)
        {
            if (transform.position.y < MinimumValueY)
            {
                transform.position = new Vector2(transform.position.x, MinimumValueY);
            }

            if (transform.position.y > MaxmumValueY)
            {
                transform.position = new Vector2(transform.position.x, MaxmumValueY);
            }

            if (transform.position.x < MinimumValueX + Player.transform.position.x)
            {
                transform.position = new Vector2(MinimumValueX + Player.transform.position.x, transform.position.y);
            }

            if (transform.position.x > MaxmumValueX + Player.transform.position.x)
            {
                transform.position = new Vector2(MaxmumValueX + Player.transform.position.x, transform.position.y);
            }
        }

        //偵測當前場景
        int index = SceneManager.GetActiveScene().buildIndex;

        //限制鼠標不超過場景邊界
        if (CursorAreaModel)
        {
            if (transform.position.x < SceneLeftValueX[index])
            {
                transform.position = new Vector2(SceneLeftValueX[index], transform.position.y);
            }

            if (transform.position.x > SceneRightValueX[index])
            {
                transform.position = new Vector2(SceneRightValueX[index], transform.position.y);
            }
        }

        if(index > 6)
        {
            Debug.Log("鼠標場景邊界限制未指定");
        }
    }
}