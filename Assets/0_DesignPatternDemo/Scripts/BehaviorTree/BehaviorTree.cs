using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BehaviorTree : Node
{
    public BehaviorTree()
    {
        name = "tree";
    }

    public BehaviorTree(string name)
    {
        this.name = name;
    }

    public string PrintTree(Node node, int level)
    {
        var treePrint = new string('-', level) + node.name + "\n";
        if (node.children.Count > 0) 
        {
            foreach (Node n in node.children)
            {
                treePrint += PrintTree(n, level+1);
            }
        }
        
        return treePrint;
    }
}
