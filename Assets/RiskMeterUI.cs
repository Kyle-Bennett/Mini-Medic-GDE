using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiskMeterUI : MonoBehaviour
{
    public Slider slider;
    public void SetMaxRisk(float risk)
    {
        slider.maxValue = risk;
        slider.value = risk;
    }

    public void setRisk(float risk)
    {
        slider.value = risk;
    }

}
