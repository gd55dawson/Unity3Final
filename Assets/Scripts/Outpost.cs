using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outpost : MonoBehaviour
{
    public static List<Outpost> OutpostList = new List<Outpost>();

    private void OnEnable()
    {
        if (OutpostList.Contains(this)) return;
        OutpostList.Add(this);
    }

    private void OnDisable()
    {
        if (OutpostList.Contains(this) == false) return;
        OutpostList.Remove(this);
    }
}
