using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : BTAgent
{
    [SerializeField] Transform obj1;
    [SerializeField] Transform obj2;
    [SerializeField] Transform otherEnemy;

    protected override void Start() 
    {
        base.Start();

        //BTree
        behaviorTree = new BehaviorTree();
        Sequence testSequence = new Sequence("test");
        Selector testSelector = new Selector("test_selector");
        Leaf goToObj1 = new Leaf("object1", GoToObj1);
        Leaf goToObj2 = new Leaf("object1", GoToObj2);
        Leaf followOtherEnemy = new Leaf("other enemy", FollowEnemy);

        testSelector.AddChildren(goToObj1);
        testSelector.AddChildren(goToObj2);
        testSequence.AddChildren(testSelector);
        testSequence.AddChildren(followOtherEnemy);
        behaviorTree.AddChildren(testSequence);
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
}
