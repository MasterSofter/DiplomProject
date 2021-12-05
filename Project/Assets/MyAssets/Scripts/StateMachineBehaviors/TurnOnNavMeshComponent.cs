using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurnOnNavMeshComponent : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var navMeshAgent = animator.gameObject.GetComponent<NavMeshAgent>();
        if (navMeshAgent != null)
            navMeshAgent.enabled = true;
    }
}
