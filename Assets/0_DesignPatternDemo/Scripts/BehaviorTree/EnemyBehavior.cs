using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Transform obj1;
    [SerializeField] Transform obj2;
    [SerializeField] Transform otherEnemy;
    NavMeshAgent agent;
    private BehaviorTree behaviorTree;
    private enum ActionState { IDLE, WORKING }
    ActionState state = ActionState.IDLE;
    Node.Status treeStatus = Node.Status.RUNNING;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();

        //BTree
        behaviorTree = new BehaviorTree();
        Sequence testSequence = testSequence = new Sequence("test");
        Leaf goToObj1 = new Leaf("object1", GoToObj1);
        Leaf goToObj2 = new Leaf("object1", GoToObj2);
        Leaf followOtherEnemy = new Leaf("other enemy", FollowEnemy);

        testSequence.AddChildren(goToObj1);
        testSequence.AddChildren(goToObj2);
        testSequence.AddChildren(followOtherEnemy);
        behaviorTree.AddChildren(testSequence);
    }

    private void Update() 
    {
        if (treeStatus == Node.Status.RUNNING)
        {
            treeStatus = behaviorTree.Process();
        }
    }

    private Node.Status GoToObj1()
    {
        return GoToLocation(obj1.position);
    }

    private Node.Status GoToObj2()
    {
        return GoToLocation(obj2.position);
    }

    private Node.Status FollowEnemy()
    {
        return GoToLocation(otherEnemy.position);
    }

    private Node.Status GoToLocation(Vector3 destination)
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
