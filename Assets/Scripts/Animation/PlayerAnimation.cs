using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerMovementController movementController;

    private void Awake()
    {
        movementController.OnMoving += () => TriggerMove();
        movementController.OnIdle += () => TriggerIdle();
        movementController.OnJump += TriggerJump;
    }

    private void TriggerMove()
    {
        animator.ResetTrigger("Jump");
        animator.ResetTrigger("Idle");
        animator.SetTrigger("Move");
    }

    private void TriggerIdle()
    {
        animator.ResetTrigger("Jump");
        animator.ResetTrigger("Move");
        animator.SetTrigger("Idle");
    }

    private void TriggerJump()
    {
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Move");
        animator.SetTrigger("Jump");
    }

    private void Trigger45DegreeShootAngle()
    {


    }
}
