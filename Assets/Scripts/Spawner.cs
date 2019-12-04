using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static List<Spawner> SpawnList = new List<Spawner>();

    private void OnEnable()
    {
        if (SpawnList.Contains(this)) return;
        SpawnList.Add(this);
    }

    private void OnDisable()
    {
        if (SpawnList.Contains(this) == false) return;
        SpawnList.Remove(this);
        // Debug.Log("WHY? U NO WORK!!!!!");
    }
}
