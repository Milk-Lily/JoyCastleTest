using System.Collections.Generic;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class LogTreeElement
{
    public List<int> LogTheLeftElementsOfTree(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        List<int> result = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        result.Add(root.val);
        int flag = 1;
        TreeNode temp;

        while (true)
        {
            int curr = 0;
            for (int i = 0; i < flag; i++)
            {
                temp = queue.Dequeue();
                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);
                    curr++;
                }
                
                if (temp.right != null)
                {
                    queue.Enqueue(temp.right);
                    curr++;
                }
            }
            
            flag = curr;
            if (flag <= 0 || queue.Count < 1)
            {
                break;
            }
            result.Add(queue.Peek().val);
        }

        return result;
    }
}