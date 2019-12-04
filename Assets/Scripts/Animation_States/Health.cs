using System;
using GameSavvy.ScriptableLibrary;
using UnityEngine;


public class Health : MonoBehaviour
{

    private AI _AI;

    public RefFloatAttribute HealthProperty { get; private set; }

    public float TeamNumber { get; private set; }

    [SerializeField]
    private float _Damage = 20f; // how much damage to take

    private void Awake()
    {
        HealthProperty = ScriptableObject.CreateInstance<RefFloatAttribute>();
        _AI =GetComponent<AI>();
    }


    public void TakeDamage()
    {
        HealthProperty.Value -= _Damage; // take damage
        HealthProperty.ClampValue();
        if(HealthProperty.Value <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        _AI.Anim.SetTrigger("Death");
    }

    public void SetTeamNumber(int num)
    {
        TeamNumber = num;
    }
}
