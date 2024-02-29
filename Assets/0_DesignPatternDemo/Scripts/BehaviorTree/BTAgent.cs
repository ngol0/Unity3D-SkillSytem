using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BTAgent : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected BehaviorTree behaviorTree;
    protected enum ActionState { IDLE, WORKING }
    protected ActionState state = ActionState.IDLE;
    protected Node.Status treeStatus = Node.Status.RUNNING;

    protected virtual void Start() 
    {
        agent = GetComponent<NavMeshAgent>();

        //BTree
        behaviorTree = new BehaviorTree();
    }

    protected virtual void Update() 
    {
        if (treeStatus == Node.Status.RUNNING)
        {
            treeStatus = behaviorTree.Process();
        }
    }

    public Node.Status GoToLocation(Vector3 destination)
    {
        float distance = Vector3.Distance(destination, transform.position);

        if (state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WORKING;
        }
        else if (Vector3.Distance(agent.pathEndPosition, destination) > 2)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distance < 2)
        {
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
}
