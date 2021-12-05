using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPlayerController : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerController = animator.GetComponent<PlayerController>();
        if (playerController != null)
            playerController.enabled = true;
    }
}
