using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private GridPosition gridPosition;

    [SerializeField] Animator unitAnimator;

    private void Awake() {
        targetPosition = transform.position;
    }

    private void Start() {
        // gridPosition = LevelGrid.instance.GetGridPosition(transform.position);
        // LevelGrid.instance.AddUnitAtGrid(gridPosition, this);
    }

    // private void Update()
    // {
    //     float stoppingDistance = 0.1f;

    //     float dist = Vector3.Distance(targetPosition, transform.position);
    //     //Debug.Log(dist);
    //     if (dist > stoppingDistance)
    //     {
    //         Vector3 moveDirection = (targetPosition - transform.position).normalized;
    //         float moveSpeed = 10f;
    //         transform.position += moveDirection * moveSpeed * Time.deltaTime;

    //         //animation for walking
    //         unitAnimator.SetBool("isWalking", true);

    //         //rotating smoothly to the target point
    //         float rotatingSpeed = 10f;
    //         //transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotatingSpeed);

    //         var lookPos = this.targetPosition - transform.position;
    //         lookPos.y = 0;
    //         var rotation = Quaternion.LookRotation(lookPos);
    //         transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotatingSpeed * Time.deltaTime);
    //     }
    //     else
    //     {
    //         unitAnimator.SetBool("isWalking", false);
    //     }

        // GridPosition newGridPosition = LevelGrid.instance.GetGridPosition(transform.position);
        // if (newGridPosition != gridPosition)
        // {
        //     LevelGrid.instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
        //     gridPosition = newGridPosition;
        // }
    //}

    // public void Move(Vector3 targetPosition)
    // {
    //     this.targetPosition = targetPosition;
    // }
}
