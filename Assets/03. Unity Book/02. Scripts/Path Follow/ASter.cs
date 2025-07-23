using System.Collections.Generic;
using UnityEngine;

public class ASter : MonoBehaviour
{
    public static AStar_PriorityQueue openList; // 방문할 수 있는 후보 노드
    public static AStar_PriorityQueue closedList; // 이미 방문한 노드

    private static float HeristicEstimateCost(AStar_Node curNode, AStar_Node destNode)
    {
        Vector3 cost = curNode.pos - destNode.pos;
        
        return cost.magnitude;
    }

    public static List<AStar_Node> FindPath(AStar_Node startNode, AStar_Node destNode)
    {
        openList = new AStar_PriorityQueue();
        openList.Push(startNode);
        startNode.nodeTotalCost = 0f;
        startNode.estimateCost = HeristicEstimateCost(startNode, destNode);
        closedList = new AStar_PriorityQueue();
        AStar_Node node = null;

        while (openList.Length != 0)
        {
            node = openList.First();
            if (node.pos == destNode.pos)
            {
                return CalculatePath(node);
            }
            
            List<AStar_Node> neighbours = new List<AStar_Node>();
            AStar_GridManager.Instance.GetNeighbors(node, neighbours);

            for (int i = 0; i < neighbours.Count; i++)
            {
                AStar_Node neighbourNode = neighbours[i];

                if (!closedList.Contains(neighbourNode))
                {
                    float cost = HeristicEstimateCost(node, neighbourNode);
                    float totalCost = node.nodeTotalCost + cost;
                    
                    float neighbourNodeEstCost = HeristicEstimateCost(neighbourNode, destNode);
                    
                    neighbourNode.nodeTotalCost = totalCost;
                    neighbourNode.parent = node;
                    neighbourNode.estimateCost = totalCost + neighbourNodeEstCost;

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Push(neighbourNode);
                    }
                }
            }
            closedList.Push(node);
            openList.Remove(node);
        }

        if (node.pos != destNode.pos)
        {
            Debug.LogError("Des Path Not Found!");
            return null;
        }

        return CalculatePath(node);
    }

    private static List<AStar_Node> CalculatePath(AStar_Node node)
    {
        List<AStar_Node> list = new List<AStar_Node>();

        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }
        list.Reverse();
        return list;
    }
    
}