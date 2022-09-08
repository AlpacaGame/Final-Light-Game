using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkFlowchart : MonoBehaviour
{

    public bool 對話框開關;

    public static Flowchart flowchartManager;
    public Flowchart talkFlowchart;

    [Header("執行的那個對話框全名")]
    public string onTriggerEnter2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && 對話框開關)
        {
            
            Block targetBlock = talkFlowchart.FindBlock(onTriggerEnter2D);
            talkFlowchart.ExecuteBlock(targetBlock);
        
        }
    }

    void OnTriggerEnter2D(Collider2D Talk)
    {
        if (Talk.gameObject.tag == "Player")
        {
            對話框開關 = true;
        }
    }

    void OnTriggerExit2D(Collider2D Talk)
    {
        if (Talk.gameObject.tag == "Player")
        {
            對話框開關 = false;
        }
    }
}
