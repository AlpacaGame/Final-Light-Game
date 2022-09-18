using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkFlowchart : MonoBehaviour
{

    public bool 對話框開關;
    public bool 撿道具觸發;
    public bool 直接觸發;
    public bool 觸發消失;

    public bool 打不開的門;

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
        if (Input.GetKey(KeyCode.E) && 對話框開關 && 撿道具觸發)
        {
            
            Block targetBlock = talkFlowchart.FindBlock(onTriggerEnter2D);
            talkFlowchart.ExecuteBlock(targetBlock);
        
        }
        if(對話框開關 && 觸發消失)
        {
            Block targetBlock = talkFlowchart.FindBlock(onTriggerEnter2D);
            talkFlowchart.ExecuteBlock(targetBlock);
            觸發消失 = false;
            Destroy(gameObject);
        }
        
        if (Input.GetKey(KeyCode.E) && 對話框開關 && 打不開的門)
        {
            Block targetBlock = talkFlowchart.FindBlock(onTriggerEnter2D);
            talkFlowchart.ExecuteBlock(targetBlock);
        }
        
        if(GameManager.擁有門禁卡)
        {
            打不開的門 = false;
        }
    }

    void OnTriggerEnter2D(Collider2D Talk)
    {
        if (Talk.gameObject.tag == "Player")
        {
            對話框開關 = true;
            if (直接觸發)
            {
                Block targetBlock = talkFlowchart.FindBlock(onTriggerEnter2D);
                talkFlowchart.ExecuteBlock(targetBlock);
            }
            //直接觸發 = true;
            //觸發消失 = true;

        }
    }

    void OnTriggerExit2D(Collider2D Talk)
    {
        if (Talk.gameObject.tag == "Player")
        {
            對話框開關 = false;
            //直接觸發 = false;
        }
    }
}
