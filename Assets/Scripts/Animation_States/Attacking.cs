using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;

public class Attacking : StateMachineBehaviour
{

    private AI _AI;

    [SerializeField]
    private PoolableObject _PoolableExplosion;

    private float _Timer = 0.5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _AI = animator.GetComponent<AI>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _Timer -= Time.deltaTime;
       if(_Timer < 0 && _AI.TargetHeatlh.enabled == true)
       {
           PoolManager.GetNext(_PoolableExplosion, _AI.TargetHeatlh.transform.position, Quaternion.identity);
           _AI.TargetHeatlh.TakeDamage();
       }
       else if(_AI.TargetHeatlh.gameObject.activeInHierarchy == false)
       {
           animator.SetTrigger("Idle");
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
