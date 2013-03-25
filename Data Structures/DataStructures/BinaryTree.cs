using System;
using System.Collections.Generic;

namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T>
    {
        #region [Properties]
        /// <summary>
        /// Root of the binary tree
        /// </summary>
        public BinaryTreeNode<T> Root { get; set; }
        
        /// <summary>
        /// Binary tree child
        /// </summary>
        public enum BinaryTreeChild
        {
            Left,
            Right
        }

        /// <summary>
        /// Binary Tree Traversal Methods
        /// </summary>
        public enum BinaryTreeTraversal
        {
            BFS,
            DFS,
            Inorder,
            Preorder,
            Postorder
        }
        #endregion
        
        #region [Constructor]
        /// <summary>
        /// Create a new instance of binary tree
        /// </summary>
        public BinaryTree()
        {
            Root = null;
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// Clear the entire binary tree
        /// </summary>
        public virtual void Clear()
        {
            Root = null;
        }

        /// <summary>
        /// Add a node in the binary tree
        /// </summary>
        /// <param name="parent">Parent node of the inserted node</param>
        /// <param name="childNode">Node to insert</param>
        /// <param name="childDirection">Position to insert new node with respect to parent</param>
        /// <param name="intermediateDirection">Position with respect to child to insert nodes which are in previous place of newly inserted node</param>
        public virtual void Add(BinaryTreeNode<T> parent, BinaryTreeNode<T> childNode, BinaryTreeChild childDirection, BinaryTreeChild intermediateDirection)
        {                        
            if (parent == null)
                throw new BinaryTreeException("Parent element must be specified while adding a node in Binary Tree");
            if (childNode == null)
                throw new BinaryTreeException("The element to be added can not be null while adding a node in Binary Tree");
            if (childDirection == null)
                throw new BinaryTreeException("The direction of child element to be inserted must be specified.");

            BinaryTreeNode<T> child;

            switch (childDirection)
            {
                case BinaryTreeChild.Left:
                    if (parent.Left == null)
                        parent.Left = childNode;
                    else
                    {
                        child = parent.Left;
                        parent.Left = childNode;
                        if (intermediateDirection == null || intermediateDirection == BinaryTreeChild.Left)
                            childNode.Left = child;
                        else
                            childNode.Right = child;
                    }
                    break;
                case BinaryTreeChild.Right: 
                    if (parent.Right == null)
                        parent.Right = childNode;
                    else
                    {
                        child = parent.Right;
                        parent.Right = childNode;
                        if (intermediateDirection == null || intermediateDirection == BinaryTreeChild.Left)
                            childNode.Left = child;
                        else
                            childNode.Right = child;
                    }
                    break;
            }  
        }


        /// <summary>
        /// Traverse a binary tree in Preorder manner starting from the root
        /// </summary>
        /// <returns>List of traversed nodes in order</returns>
        public virtual List<T> Traverse()
        {
            return PreorderTraversal(Root);
        }

        /// <summary>
        /// Traverse a binary tree in Preorder manner
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <returns>List of traversed nodes in order</returns>
        public virtual List<T> Traverse(BinaryTreeNode<T> parentNode)
        {
            return PreorderTraversal(parentNode);
        }

        /// <summary>
        /// Traverse a binary tree starting from the root
        /// </summary>
        /// <param name="traversalMethod">One of the five Traversal method</param>
        /// <returns>List of traversed nodes in order</returns>
        public virtual List<T> Traverse(BinaryTreeTraversal traversalMethod)
        {
            List<T> traversedList = new List<T>();
            switch (traversalMethod)
            {
                case BinaryTreeTraversal.BFS: traversedList = BFSTraversal(Root);
                    break;
                case BinaryTreeTraversal.DFS: traversedList = DFSTraversal(Root);
                    break;
                case BinaryTreeTraversal.Inorder: traversedList = InorderTraversal(Root);
                    break;
                case BinaryTreeTraversal.Postorder: traversedList = PostorderTraversal(Root);
                    break;
                case BinaryTreeTraversal.Preorder: traversedList = PreorderTraversal(Root);
                    break;
            }
            return traversedList;
        }

        /// <summary>
        /// Traverse a Binary Tree
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <param name="traversalMethod">One of the 5 traversal method</param>
        /// <returns>List of traversed node in order</returns>
        public virtual List<T> Traverse(BinaryTreeNode<T> parentNode, BinaryTreeTraversal traversalMethod)
        {
            List<T> traversedList = new List<T>();
            switch (traversalMethod)
            {
                case BinaryTreeTraversal.BFS: traversedList = BFSTraversal(parentNode);
                    break;
                case BinaryTreeTraversal.DFS: traversedList = DFSTraversal(parentNode);
                    break;
                case BinaryTreeTraversal.Inorder: traversedList = InorderTraversal(parentNode);
                    break;
                case BinaryTreeTraversal.Postorder: traversedList = PostorderTraversal(parentNode);
                    break;
                case BinaryTreeTraversal.Preorder: traversedList = PreorderTraversal(parentNode);
                    break;
            }
            return traversedList;
        }
        
        /// <summary>
        /// Traverse a binary tree in Breadth-First manner
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <returns>List of traversed node</returns>
        public List<T> BFSTraversal(BinaryTreeNode<T> parentNode)
        {
            List<T> traversedList = new List<T>();
            if (parentNode == null)
                return traversedList;
            Queue<BinaryTreeNode<T>> traversedQueue = new Queue<BinaryTreeNode<T>>();
            traversedQueue.Enqueue(parentNode);
            BinaryTreeNode<T> node;
            while (traversedQueue.Count > 0)
            {
                node = traversedQueue.Dequeue();
                traversedList.Add(node.Value);
                if(node.Left != null)
                    traversedQueue.Enqueue(node.Left);
                if(node.Right != null)
                    traversedQueue.Enqueue(node.Right);
            }
            return traversedList;
        }

        /// <summary>
        /// Traverse a binary tree in Depth-First manner
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <returns>List of traversed node</returns>
        public List<T> DFSTraversal(BinaryTreeNode<T> parentNode)
        {
            List<T> traversedList = new List<T>();
            if (parentNode == null)
                return traversedList;
            Stack<BinaryTreeNode<T>> traversedStack = new Stack<BinaryTreeNode<T>>();
            traversedStack.Push(parentNode);
            BinaryTreeNode<T> node;
            while (traversedStack.Count > 0)
            {
                node = traversedStack.Pop();
                traversedList.Add(node.Value);
                if (node.Right != null)
                    traversedStack.Push(node.Right);
                if (node.Left != null)
                    traversedStack.Push(node.Left);
            }
            return traversedList;
        }

        /// <summary>
        /// Traverse a binary search tree in Inorder manner
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <returns>List of traversed node</returns>
        public List<T> InorderTraversal(BinaryTreeNode<T> parentNode)
        {
            List<T> traversedList = new List<T>();
            Stack<BinaryTreeNode<T>> traversedStack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> node = parentNode;
            while (traversedStack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    traversedStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = traversedStack.Pop();
                    traversedList.Add(node.Value);
                    node = node.Right;
                }
            }
            return traversedList;
        }

        /// <summary>
        /// Traverse a binary tree in Preorder manner
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <returns>List of traversed node</returns>
        public List<T> PreorderTraversal(BinaryTreeNode<T> parentNode)
        {
            List<T> traversedList = new List<T>();
            Stack<BinaryTreeNode<T>> traversedStack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> node = parentNode;
            while (traversedStack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    traversedStack.Push(node);
                    traversedList.Add(node.Value);
                    node = node.Left;
                }
                else
                {
                    node = traversedStack.Pop();
                    node = node.Right;
                }
            }
            return traversedList;
        }


        /// <summary>
        /// Traverse a binary search tree in Postorder manner
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <returns>List of traversed node</returns>
        public List<T> PostorderTraversal(BinaryTreeNode<T> parentNode)
        {
            List<T> traversedList = new List<T>();
            Stack<BinaryTreeNode<T>> traversedStack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T>  currNode, prevNode = null;

            if (parentNode != null)
            {
                traversedStack.Push(parentNode);
                while (traversedStack.Count > 0)
                {
                    currNode = traversedStack.Peek();
                    if (prevNode == null || prevNode.Left == currNode || prevNode.Right == currNode)
                    {
                        if (currNode.Left != null)
                            traversedStack.Push(currNode.Left);
                        else if (currNode.Right != null)
                            traversedStack.Push(currNode.Right);
                    }
                    else if (currNode.Left == prevNode)
                    {
                        if (currNode.Right != null)
                            traversedStack.Push(currNode.Right);
                    }
                    else
                    {
                        traversedList.Add(currNode.Value);
                        traversedStack.Pop();
                        prevNode = currNode;
                    }
                }
            }

            return traversedList;
        }

        /// <summary>
        /// Traverse a binary search tree in Inorder manner recursively
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <param name="traversedList">List where the result will be stored</param>
        public void InorderTraversalRecursive(BinaryTreeNode<T> parentNode, ref List<T> traversedList)
        {            
            if (parentNode != null)
            {
                InorderTraversalRecursive(parentNode.Left, ref traversedList);
                traversedList.Add(parentNode.Value);
                InorderTraversalRecursive(parentNode.Right, ref traversedList);
            }                            
        }

        /// <summary>
        /// Traverse a binary search tree in Preorder manner recursively
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <param name="traversedList">List where the result will be stored</param>
        public void PreorderTraversalRecursive(BinaryTreeNode<T> parentNode, ref List<T> traversedList)
        {
            if (parentNode != null)
            {
                traversedList.Add(parentNode.Value);
                PreorderTraversalRecursive(parentNode.Left, ref traversedList);                
                PreorderTraversalRecursive(parentNode.Right, ref traversedList);
            }
        }

        /// <summary>
        /// Traverse a binary search tree in Postorder manner recursively
        /// </summary>
        /// <param name="parentNode">Traversal start node</param>
        /// <param name="traversedList">List where the result will be stored</param>
        public void PostorderTraversalRecursive(BinaryTreeNode<T> parentNode, ref List<T> traversedList)
        {
            if (parentNode != null)
            {                
                PostorderTraversalRecursive(parentNode.Left, ref traversedList);
                PostorderTraversalRecursive(parentNode.Right, ref traversedList);
                traversedList.Add(parentNode.Value);
            }
        }
        #endregion
    }
}
