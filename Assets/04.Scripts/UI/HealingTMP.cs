using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealingTMP : MonoBehaviour
{
    public TextMeshProUGUI 干﹀警;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        干﹀警 = transform.GetComponent<TextMeshProUGUI>();

        string 鮔干﹀警计秖 = GameManager.干计秖.ToString();

            // 盢ゅ砞﹚UI Texttext妮┦
        干﹀警.text = 鮔干﹀警计秖;

    }
}
