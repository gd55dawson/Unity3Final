using System;
using System.Collections;
using System.Collections.Generic;
using GameSavvy.OpenUnityAttributes;
using GameSavvy.ScriptableLibrary;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptables/RefFloatAttribute")] // sets it up so we can call it from create
public class RefFloatAttribute : RefFloat

{
    [SerializeField]
    private float _Min;

    [SerializeField]
    private float _Max;

    public void ClampValue()
    {
        Value = Mathf.Clamp(Value, _Min, _Max); // attempt number 2
    }

    public float GetPercent()
    {
        return (Value - _Min) / (_Max - _Min); // sets min and max value
    }
}
