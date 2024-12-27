using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxResource(float resource)
    {
        slider.maxValue = resource;
        slider.value = resource;
        Debug.Log("Max health set");
    }
    public void SetResource(float resource)
    {
        slider.value = resource;
        Debug.Log("Health Changed");
    }
}
