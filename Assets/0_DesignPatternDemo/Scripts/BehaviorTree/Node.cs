using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public enum Status { SUCCESS, RUNNING, FAILURE }
    public Status currentStatus;
    public List<Node> children = new List<Node>();
    public int currentChildrenNode = 0;
    public string name;

    public Node()
    {
        name = "default";
    }

    public Node(string n)
    {
        name = n;
    }

    public void AddChildren(Node n)
    {
        children.Add(n);
    }

    public virtual Status Process()
    {
        return children[currentChildrenNode].Process();
    }
}
