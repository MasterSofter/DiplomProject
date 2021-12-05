using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffCharacterController : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var characterController = animator.GetComponent<CharacterController>();
        if (characterController != null)
            characterController.enabled = false;
    }
}
