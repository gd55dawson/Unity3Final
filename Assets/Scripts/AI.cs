using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    private Idle _Idle;
    private NavMeshAgent _Agent;
    private Health _Health;

    public Outpost TargetOutpost { get; private set; }

    public Animator Anim {get; private set;}

    public Health TargetHeatlh { get; private set; }


    private void Awake()
    {
        Anim = GetComponent<Animator>();

        _Health = GetComponent<Health>();

        _Agent = GetComponent<NavMeshAgent>();

    }
    public void SetTargetOutpost(Outpost tOutpost)
    {
        TargetOutpost = tOutpost;
    }

    public void SetDestination()
    {
        _Agent.SetDestination(TargetOutpost.transform.position);
    }

    private void StopMovement()
    {
        _Agent.isStopped = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("!ATTACK", gameObject);
        Health otherHealth = other.GetComponentInParent<Health>();

        if (otherHealth != null && otherHealth.TeamNumber != _Health.TeamNumber) // checks if opposite teams bump into each other
        {
            Debug.Log("ATTACK!", gameObject);
            TargetHeatlh = otherHealth;
            StopMovement();
            Anim.SetTrigger("Attacking");
        }
    }
    

}
