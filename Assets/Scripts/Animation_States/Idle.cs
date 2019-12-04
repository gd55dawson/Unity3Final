using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{

    private Outpost _TargetOutpost;
    private AI _AI;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _AI = animator.GetComponent<AI>();
        _TargetOutpost = Outpost.OutpostList.GetRandom();

        _AI.SetTargetOutpost(_TargetOutpost);

        animator.SetTrigger("Move");
    }
}
