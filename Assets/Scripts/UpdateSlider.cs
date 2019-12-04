using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSlider : MonoBehaviour
{
    private RefFloatAttribute _HealthSO; // sets up HEALTHSO

    [SerializeField]
    private Image _Slider; //Slider
    private float _SliderTarget = 100;
    private float _ref;

    private void Awake()
    {
        _HealthSO = GetComponentInParent<Health>().HealthProperty;
        _HealthSO.Observers += ChangeSlider; // Subs to Changeslider
    }

    private void OnDisable()
    {
        _HealthSO.Observers -= ChangeSlider; // Unsubs from Changeslider
    }

    private void ChangeSlider(float healthValue) 
    {
        //print( _HealthSO.GetPercent()); //Prints health percent
        _SliderTarget = Mathf.Clamp(healthValue, 0, 1); // clamps health between 0 - 100 slider
        
        print(Mathf.Clamp(healthValue, 0, 1)); // prints health val between min and max value
    }

    private void Update()
    {
        _Slider.fillAmount = Mathf.SmoothDamp(0, _SliderTarget, ref _ref, 0.2f, 10000); //smoothly animates the health from the health value and slider target
    }


}
