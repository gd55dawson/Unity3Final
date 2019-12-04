using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToWaypoint : StateMachineBehaviour
{
    private Vector3 _Destination;

    private AI _AI;

    [SerializeField]
    private float _MinimumDistance = 2f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _AI = animator.GetComponent<AI>();


        _Destination = _AI.TargetOutpost.transform.position;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _AI.SetDestination();
        float distance = Vector3.Distance (animator.transform.position, _Destination);
        Debug.Log(distance);
        if (distance < _MinimumDistance)
        {
            Debug.Log("Idle Is called");
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
