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
}
