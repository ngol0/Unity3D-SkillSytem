using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public Sequence()
    {
        name = "Sequence default";
    }

    public Sequence(string n)
    {
        name = n;
    }

    public override Status Process()
    {
        Status childStatus = children[currentChildrenNode].Process();
        if (childStatus == Status.FAILURE)
        {
            return childStatus;
        }
        else if (childStatus == Status.SUCCESS)
        {
            currentChildrenNode++;
            if (currentChildrenNode >= children.Count)
            {
                currentChildrenNode = 0;
                return Status.SUCCESS;
            }
        }
        return Status.RUNNING;
    }
}
