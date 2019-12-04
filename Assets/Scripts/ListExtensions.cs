using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static T GetRandom<T>(this List<T> list)
    {
        if(list == null) return default(T);
        if(list.Count <= 0) return default(T);
        int i = Random.Range(0, list.Count);
        return list[i];
    }
}
