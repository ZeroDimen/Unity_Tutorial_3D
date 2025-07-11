using System;
using UnityEngine;

// 이진 탐색 트리의 예시 
public class BinarySearchTree : MonoBehaviour 
{
    // 중첩 클레스
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }

    private TreeNode root;
    private int[] array = { 8, 3, 10, 1, 6, 14, 4, 7, 13 }; // 배열
    
    private string result;

    void Start()
    {
        foreach (var v in array)
        {
            root = Insert(root, v);
        }
        
        PreOrder(root);
        Debug.Log($"PreOrder : {result}");

        result = String.Empty;
        InOrder(root);
        Debug.Log($"InOrder : {result}");
        
        result = String.Empty;
        PostOrder(root);
        Debug.Log($"PostOrder : {result}");
    }
    
    private TreeNode Insert(TreeNode node, int value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        if (value < node.value)
        {
            node.left = Insert(node.left, value);
        }
        else
        {
            node.right = Insert(node.right, value);
        }
        return node;
    }

    private void PreOrder(TreeNode node) // 전위 순회
    {
        if (node == null)
        {
            return;
        }
        
        result += $"{node.value}, ";
        PreOrder(node.left);
        PreOrder(node.right);
    }

    private void InOrder(TreeNode node) // 중위 순회
    {
        if (node == null)
        {
            return;
        }
           
        InOrder(node.left);
        result += $"{node.value}, ";
        InOrder(node.right);
    }

    private void PostOrder(TreeNode node) // 후위 순회
    {
        if (node == null)
        {
            return;
        }
            
        PostOrder(node.left);
        PostOrder(node.right);
        result += $"{node.value}, ";
    }
    
    
    
}