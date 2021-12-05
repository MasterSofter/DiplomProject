using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCharacterController : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var characterController = animator.gameObject.GetComponent<CharacterController>();
        if (characterController != null)
            characterController.enabled = true;
    }
}
