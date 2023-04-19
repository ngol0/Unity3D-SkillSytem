using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour, IAction
{
    private ActionManager actionScheduler;
    private PlayerMove movementControl;
    private GameObject targetToAttack;
    private Animator animator;
    private float inRangeDistance = 2f;
    private void Start() 
    {
        actionScheduler = GetComponent<ActionManager>();
        movementControl = GetComponent<PlayerMove>();
        animator = GetComponent<PlayerController>().Anim;
    }

    private void Update() 
    {
        if (targetToAttack == null) return;
        if (!IsInRange())
        {
            movementControl.MoveTo(targetToAttack.transform.position);
        }
        else
        {
            movementControl.Cancel();
            TriggerAttackBehavior();
        }
    }

    private void TriggerAttackBehavior()
    {
        animator.SetTrigger("startAttack");
    }

    private bool IsInRange()
    {
        return (Vector3.Distance(transform.position, targetToAttack.transform.position) < inRangeDistance);
    }

    public void Attack(GameObject target)
    {
        Cancel();
        targetToAttack = target;
        actionScheduler.StartAction(this);
    }

    public bool CanAttack(GameObject target)
    {
        return true;
    }

    public void Cancel()
    {
        targetToAttack = null;
        movementControl.Cancel();
        animator.ResetTrigger("startAttack");
        animator.SetTrigger("stopAttack");
    }
}
