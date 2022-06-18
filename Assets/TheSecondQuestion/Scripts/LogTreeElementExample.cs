using System;
using UnityEngine;

public class LogTreeElementExample : MonoBehaviour
{
    private void Start()
    {
        LogTreeLeftNode();
    }

    private void LogTreeLeftNode()
    {
        LogTreeElement logTreeElement = new LogTreeElement();
        var nodeList = logTreeElement.LogTheLeftElementsOfTree(GetTree());
        if (nodeList == null)
        {
            Debug.LogError("Tree is Empty!");
            return;
        }
        
        string result = "";
        foreach (var value in nodeList)
        {
            result += value + ", ";
        }
        Debug.Log(result);
    }

    private TreeNode GetTree()
    {
        return new TreeNode(2,
            new TreeNode(11, new TreeNode(10), new TreeNode(15)),
            new TreeNode(23, 
                new TreeNode(7, null, new TreeNode(12, new TreeNode(13))), 
                new TreeNode(14)));
    }
}
