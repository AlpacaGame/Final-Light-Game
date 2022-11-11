using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Effect : MonoBehaviour
{

    public GameObject 滑鏟擺放位置;

    public GameObject 滑鏟效果預設物;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 煙幕效果()
    {
        Vector3 效果pos = 滑鏟擺放位置.transform.position + new Vector3(0, 0, 0);
        Instantiate(滑鏟效果預設物, 效果pos, 滑鏟擺放位置.transform.rotation);
    }
}
