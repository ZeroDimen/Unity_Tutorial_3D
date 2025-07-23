using System.Collections.Generic;
using UnityEngine;

public class AStar_GridManager : Singleton<AStar_GridManager>
{
    public GameObject[] obstacles;
    public AStar_Node[,] nodes { get; set; }

    public int numOfRows;
    public int numOfCols;
    public float gridCellSize;
    
    private Vector3 origin = new Vector3();

    public Vector3 Origin
    {
        get{return origin;}
    }

    void Awake()
    {
         obstacles =GameObject.FindGameObjectsWithTag("Obstacle");
         CalculateObstacles();
    }

    private void CalculateObstacles()
    {
        nodes = new AStar_Node[numOfRows, numOfCols];
        
        int index = 0;
        for (int i = 0; i < numOfCols; i++)
        {
            for (int j = 0; j < numOfRows; j++)
            {
                Vector3 cellpos = GetGridCellCenter(index);
                AStar_Node node = new AStar_Node(cellpos);
                // nodes[j,i] = node;
                nodes[i,j] = node;
                index++;
            }
        }

        if (obstacles != null && obstacles.Length > 0)
        {
            foreach (var obstacle in obstacles)
            {
                int indexCell = GetGridIndex(obstacle.transform.position);
                int row = indexCell / numOfCols;
                int col = indexCell % numOfCols;
                nodes[row, col].MarkAsObstacle();
            }
        }
    }

    public Vector3 GetGridCellCenter(int index)
    {
        Vector3 CellPosition = GetGridCellPosition(index);
        CellPosition.x += gridCellSize / 2f;
        CellPosition.z += gridCellSize / 2f;
        
        return CellPosition;
    }

    public Vector3 GetGridCellPosition(int index) // 현재 샐의 위치값을 구하는 함수
    {
        int row = GetRow(index);
        int col = GetCols(index);
        float xPosInGrid = col * gridCellSize;
        float zPosInGrid = row * gridCellSize;
        
        return Origin + new Vector3(xPosInGrid, 0.0f, zPosInGrid);
    }

    public int GetGridIndex(Vector3 pos)
    {
        if (!isInBounds(pos))
        {
            return -1;
        }
        pos += Origin;
        int col = (int)(pos.x / gridCellSize);
        int row = (int)(pos.z / gridCellSize);
        
        return row * numOfCols + col;
    }

    public bool isInBounds(Vector3 pos)
    {
        float width = numOfCols * gridCellSize;
        float height = numOfRows * gridCellSize;
        
        return pos.x >= Origin.x && pos.x <= Origin.x + width && pos.z >= Origin.z && pos.z <= Origin.z + height;
    }

    public int GetRow(int index)
    {
        int row = index / numOfCols;
        return row;
    }
    
    public int GetCols(int index)
    {
        int cols = index % numOfCols;
        return cols;
    }

    public void GetNeighbors(AStar_Node node, List<AStar_Node> neighbors)
    {
        int nodeIndex = GetGridIndex(node.pos);
        int row = GetRow(nodeIndex);
        int cols = GetCols(nodeIndex);
        
        // 아래쪽
        int leftNodeRow = row - 1;
        int leftNodeCol = cols;
        AssignNeighbors(leftNodeRow, leftNodeCol, neighbors);
        // 위쪽
         leftNodeRow = row + 1;
         leftNodeCol = cols;
         AssignNeighbors(leftNodeRow, leftNodeCol, neighbors);
        
        // 오른쪽
         leftNodeRow = row;
         leftNodeCol = cols + 1;
         AssignNeighbors(leftNodeRow, leftNodeCol, neighbors);
        // 왼쪽
         leftNodeRow = row ;
         leftNodeCol = cols - 1;
         AssignNeighbors(leftNodeRow, leftNodeCol, neighbors);
        
    }

    private void AssignNeighbors(int row, int col, List<AStar_Node> neighbors)
    {
        if (row != -1 && col != -1 && row < numOfRows && col < numOfCols)
        {
            AStar_Node nodeToAdd = nodes[row, col];
            if (!nodeToAdd.isObstacle)
            {
                neighbors.Add(nodeToAdd);
            }
        }
    }

    void OnDrawGizmos()
    {
        DebugDrawGrid(transform.position, numOfRows, numOfCols,gridCellSize , Color.blue);
    }
    
    public void DebugDrawGrid(Vector3 origin, int numRow, int numcols, float cellSize , Color color)
    {
        float width = numcols *cellSize;
        float height = numRow * cellSize;

        for (int i = 0; i < numRow; i++)
        {
            Vector3 startPos = origin + i * cellSize * new Vector3(0, 0, 1);
            Vector3 endPos = startPos + width * new Vector3(1, 0, 0);
            Debug.DrawLine(startPos, endPos, color);
        }
        
        for (int i = 0; i < numcols; i++)
        {
            Vector3 startPos = origin + i * cellSize * new Vector3(1, 0, 0);
            Vector3 endPos = startPos + height * new Vector3(0, 0, 1);
            Debug.DrawLine(startPos, endPos, color);
        }
    }
}