using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IAction
{
    private Vector3 targetPosition;
    ActionManager actionScheduler;
    Animator unitAnimator;
    
    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start() 
    {
        actionScheduler = GetComponent<ActionManager>();
        unitAnimator = GetComponent<PlayerController>().Anim;
    }

    private void Update() 
    {
        HandleMovement();
    }

    public void StartMoveAction(Vector3 targetPosition)
    {
        actionScheduler.StartAction(this);
        MoveTo(targetPosition);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void HandleMovement()
    {
        float stoppingDistance = 0.1f;

        float dist = Vector3.Distance(targetPosition, transform.position);
        //Debug.Log(dist);
        if (dist > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 10f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            //animation for walking
            unitAnimator.SetBool("isRunning", true);

            //rotating smoothly to the target point
            float rotatingSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotatingSpeed);

            // var lookPos = this.targetPosition - transform.position;
            // lookPos.y = 0;
            // var rotation = Quaternion.LookRotation(lookPos);
            // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotatingSpeed * Time.deltaTime);
        }
        else
        {
            unitAnimator.SetBool("isRunning", false);
        }
    }

    public void Cancel()
    {
        targetPosition = transform.position;
        unitAnimator.SetBool("isRunning", false);
    }
}
