using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Slider 體能量計;

    public Gradient 漸層色;

    public Image 填充色;

    public void 血量極限(int 計量值)
    {
        體能量計.maxValue = 計量值;
        體能量計.value = 計量值;
        填充色.color = 漸層色.Evaluate(1.0f);
    }
    public void 血量剩餘(int 計量值)
    {
        體能量計.value = 計量值;
        填充色.color = 漸層色.Evaluate(體能量計.normalizedValue);
    }
}
