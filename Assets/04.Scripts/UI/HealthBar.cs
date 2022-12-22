using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Spore_Boos sporeBoss;
	public Slider slider;

	void Start()
	{
		slider.maxValue = sporeBoss.Hp;
	}

	// Update is called once per frame
	void Update()
    {
		slider.value = sporeBoss.Hp;
    }
}
