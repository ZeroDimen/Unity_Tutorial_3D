using System.Collections.Generic;
using UnityEngine;

public class AStar_PriorityQueue : MonoBehaviour
{
    private List<AStar_Node> nodes = new List<AStar_Node>();

    public int Length
    {
        get{return nodes.Count;}
    }

    public bool Contains(AStar_Node node)
    {
        return nodes.Contains(node);
    }

    public AStar_Node First()
    {
        if (nodes.Count == 0)
        {
            return null;
        }
        return nodes[0];
    }

    public void Push(AStar_Node node)
    {
        nodes.Add(node);
        nodes.Sort();
    }

    public void Remove(AStar_Node node)
    {
        nodes.Remove(node);
        nodes.Sort();
    }
}
