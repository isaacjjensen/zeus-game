using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSlicerUsage : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsUsing", true);
        animator.gameObject.GetComponent<DelayTrailEmission>().DelayedTrailEmission(animator, true, 0.333f);
        animator.gameObject.GetComponent<DelayTrailEmission>().DelayedTrailEmission(animator, false, 0.666f);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsUsing", false);
    }
}
