using UnityEngine;

/// <summary>
/// This class will reset up to two triggers. This will avoid them to be fired while the animation is playing. 
/// </summary>
public class ResetTrigger : StateMachineBehaviour
{
    public string TriggerNameA;
    public string TriggerNameB;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (TriggerNameA != "") 
            animator.ResetTrigger(TriggerNameA);

        if (TriggerNameB != "")
            animator.ResetTrigger(TriggerNameB);
    }
}
