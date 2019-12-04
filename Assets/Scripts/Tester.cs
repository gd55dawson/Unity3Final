using System;
using ObjectPooling;
using UnityEngine;

public class Tester : MonoBehaviour
{

    [SerializeField]
    private AI _AIPrefab;

    [SerializeField]
    private PoolableObject _PoolableAI;

    [SerializeField]
    private int _TotalAITeams = 2;
    [SerializeField]
    private int _AICountPerTeam = 10;



    private void Start()
    {
        for (int currentTeam = 0; currentTeam < _TotalAITeams; currentTeam++)
        {
            for (int aIUnit = 0; aIUnit < _AICountPerTeam; aIUnit++)
            {
                Spawner spawner = Spawner.SpawnList.GetRandom();
                PoolableObject clone = PoolManager.GetNext(_PoolableAI, spawner.transform.position, Quaternion.identity, true);
                clone.GetComponent<Health>().SetTeamNumber(currentTeam);
            }
        }
    }
}
