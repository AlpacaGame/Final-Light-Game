using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    public float moveSpeed = 10f;

    public float distance;

    public float scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distance = Mathf.Abs(transform.position.x - cursorPos.x) + Mathf.Abs(transform.position.y - cursorPos.y);
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime * distance);
        scaleChange = 0.2f + distance/5;
        transform.localScale = new Vector3(scaleChange, scaleChange, 1);
    }
}
