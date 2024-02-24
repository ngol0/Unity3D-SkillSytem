using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    public delegate Status Implementation();
    Implementation ProcessMethod;

    public Leaf()
    {
        name = "Leaf default";
    }

    public Leaf(string n, Implementation method)
    {
        ProcessMethod = method;
    }

    public override Status Process()
    {
        if (ProcessMethod != null)
            return ProcessMethod();
        else
            return Status.FAILURE;
    }
}
