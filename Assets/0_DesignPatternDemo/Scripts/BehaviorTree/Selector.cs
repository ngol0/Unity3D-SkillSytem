using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public Selector()
    {
        name = "Selector default";
    }

    public Selector(string n)
    {
        name = n;
    }

    public override Status Process()
    {
        Status childStatus = children[currentChildrenNode].Process();
        if (childStatus == Status.FAILURE)
        {
            currentChildrenNode++;
            if (currentChildrenNode >= children.Count)
            {
                return Status.FAILURE;
            }
        }
        else if (childStatus == Status.SUCCESS)
        {
            currentChildrenNode = 0;
            return childStatus;
        }
        return Status.RUNNING;
    }
}
