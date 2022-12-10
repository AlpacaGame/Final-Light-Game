using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool destroy = true;
    public bool visible = true;
    void Start()
    {
        if(!destroy)
        {
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {
        if(!visible)
        {
            Cursor.visible = false;
        }
    }
}
