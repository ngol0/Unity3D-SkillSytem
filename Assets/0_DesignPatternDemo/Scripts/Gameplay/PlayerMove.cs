using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour, IAction
{
    ActionManager actionScheduler;
    Animator unitAnimator;
    NavMeshAgent navMesh;
    float moveSpeed = 10f;
    Vector3 velocity;
    Vector3 localVelocity;

    private void Start() 
    {
        actionScheduler = GetComponent<ActionManager>();
        unitAnimator = GetComponent<PlayerController>().Anim;
        navMesh = GetComponent<NavMeshAgent>();
    }

    private void Update() 
    {
        UpdateMovementAnim();
    }

    public void StartMoveAction(Vector3 targetPosition)
    {
        actionScheduler.StartAction(this);
        MoveTo(targetPosition);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        navMesh.destination = targetPosition;
        navMesh.speed = moveSpeed;
        navMesh.isStopped = false;
    }

    private void UpdateMovementAnim()
    {
        velocity = navMesh.velocity;
        localVelocity = transform.InverseTransformDirection(velocity); //the velocity of the player (z axis)
        unitAnimator.SetFloat("speed", localVelocity.z);
    }

    public void Cancel()
    {
        navMesh.isStopped = true;
    }

    // private void HandleMovement()
    // {
    //     float stoppingDistance = 0.1f;

    //     float dist = Vector3.Distance(targetPosition, transform.position);
    //     if (dist > stoppingDistance)
    //     {
    //         Vector3 moveDirection = (targetPosition - transform.position).normalized;
    //         float moveSpeed = 10f;
    //         transform.position += moveDirection * moveSpeed * Time.deltaTime;

    //         //animation for walking
    //         unitAnimator.SetBool("isRunning", true);

    //         //rotating smoothly to the target point
    //         float rotatingSpeed = 10f;
    //         transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotatingSpeed);

    //         // var lookPos = this.targetPosition - transform.position;
    //         // lookPos.y = 0;
    //         // var rotation = Quaternion.LookRotation(lookPos);
    //         // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotatingSpeed * Time.deltaTime);
    //     }
    //     else
    //     {
    //         unitAnimator.SetBool("isRunning", false);
    //     }
    // }
}
    