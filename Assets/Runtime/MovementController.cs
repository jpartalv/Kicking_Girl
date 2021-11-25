using UnityEngine;
/// <summary>
/// Class to keep track of whether this a jump movement or if we need to disable the movement in the character controller script 
/// </summary>
public class MovementController : StateMachineBehaviour
{
    public bool DisableMovement = false;
    public bool EnableJump = false;

    public static bool IsMovementDisabled;
    public static bool IsJumpEnabled;

    public string TransitionNameMovement; // don't reset on transition name

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (DisableMovement)
            IsMovementDisabled = true;
        if (EnableJump)
            IsJumpEnabled = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(animator.GetAnimatorTransitionInfo(0).IsName(TransitionNameMovement));

        if (animator.GetAnimatorTransitionInfo(0).IsName(TransitionNameMovement))
            IsMovementDisabled = false;
        
        IsJumpEnabled = false;
    }
}
