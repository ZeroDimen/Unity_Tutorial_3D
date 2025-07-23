using System;
using System.Collections.Generic;
using UnityEngine;

public class AStar_Mover : MonoBehaviour
{
    private Transform startPos, endPos;
    public AStar_Node startNode, destNode;
    
    public List<AStar_Node> pathList = new List<AStar_Node>();

    public GameObject startCube, endCube;

    void Start()
    {
        GetPath();
    }

    void GetPath()
    {
        startPos = startCube.transform;
        endPos = endCube.transform;

        int startIndex = AStar_GridManager.Instance.GetGridIndex(startPos.position);
        int startRow = AStar_GridManager.Instance.GetRow(startIndex);
        int startCols = AStar_GridManager.Instance.GetCols(startIndex);
        startNode = AStar_GridManager.Instance.nodes[startRow, startCols];
        
        int endIndex = AStar_GridManager.Instance.GetGridIndex(endPos.position);
        int endRow = AStar_GridManager.Instance.GetRow(endIndex);
        int endCols = AStar_GridManager.Instance.GetCols(endIndex);
        destNode = AStar_GridManager.Instance.nodes[endRow, endCols];
        
        // Astar에게 start와 dest 지점을 알려주고 길을 알려달라고 설정
        
        pathList = ASter.FindPath(startNode, destNode);
    }

    private void OnDrawGizmos()
    {
        if (pathList == null)
        {
            return;
        }

        if (pathList.Count > 0)
        {
            int index = 1;
            foreach (AStar_Node node in pathList)
            {
                if (index < pathList.Count)
                {
                    AStar_Node nextNode = pathList[index];
                    Debug.DrawLine(node.pos , nextNode.pos , Color.green);
                    index++;
                }
            }
        }
    }
}

