using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [Header("公夹竚")]

    public bool CursorAreaModel = false;

    public float MinimumValueY = -0.75f;
    public float MaxmumValueY = 2.5f;

    public GameObject CursorManager;
    public GameObject Player;

    public float MinimumValueX = -3.5f;
    public float MaxmumValueX = 3.5f;

    void Start()
    {
        CursorManager = transform.parent.gameObject;//ン公夹X把σ
        Player = CursorManager.transform.parent.gameObject;
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

        //公夹竚

        if(CursorAreaModel)
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
    }
}
