using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealingTMP : MonoBehaviour
{
    public TextMeshProUGUI �ɦ徯;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        �ɦ徯 = transform.GetComponent<TextMeshProUGUI>();

        string �Y�ɦ^�X�ɦ徯�ƶq = GameManager.�ɥ]�ƶq.ToString();

            // �N��r�]�w��UI Text��text�ݩ�
        �ɦ徯.text = �Y�ɦ^�X�ɦ徯�ƶq;

    }
}
