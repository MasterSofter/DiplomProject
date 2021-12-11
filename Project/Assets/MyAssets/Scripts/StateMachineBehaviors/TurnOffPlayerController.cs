using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Core;

public class TurnOffPlayerController : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var playerController = animator.GetComponent<PlayerCore>();
        if (playerController != null)
            playerController.enabled = false;
    }
}
