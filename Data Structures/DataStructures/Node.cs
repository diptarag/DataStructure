using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataStructures
{
    /// <summary>
    /// Represents a node of a tree which has a value and many child nodes
    /// </summary>
    /// <typeparam name="T">Type of node value</typeparam>
    public class Node<T>
    {
        #region [Properties]
        /// <summary>
        /// Value of the Node
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// children of the Node
        /// </summary>
        protected NodeList<T> Neighbours { get; set; }
        #endregion

        #region [Constructors]
        /// <summary>
        /// Create a new Node
        /// </summary>
        public Node() { }
        /// <summary>
        /// Create a new Node
        /// </summary>
        /// <param name="data">Value of the node</param>
        public Node(T data) : this(data, null) { }
        /// <summary>
        /// Create a new Node
        /// </summary>
        /// <param name="data">Value of the node</param>
        /// <param name="neighbors">Children of the nodes</param>
        public Node(T data, NodeList<T> neighbors)
        {
            Value = data;
            Neighbours = neighbors;
        }
        #endregion        
    }

    /// <summary>
    /// Represents the children of a Node 
    /// </summary>
    /// <typeparam name="T">Type of the value in Node</typeparam>
    public class NodeList<T> : Collection<Node<T>>
    {
        #region [Constructors]
        /// <summary>
        /// Create a list of nodes to be used as children of another node
        /// </summary>
        public NodeList() : base() { }

        /// <summary>
        /// Create a list of nodes to be used as children of another node
        /// </summary>
        /// <param name="initialSize">Initial size of child nodes</param>
        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
                base.Items.Add(default(Node<T>));
        }        
        #endregion

        #region [Public Methods]
        /// <summary>
        /// Find a node in a child collection by value of the node
        /// </summary>
        /// <param name="value">Value to be found</param>
        /// <returns>Node with the specified value, null if not found</returns>
        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
        #endregion

    }

    /// <summary>
    /// Represents a node of a binary tree
    /// </summary>
    /// <typeparam name="T">Type of the value in node</typeparam>
    public class BinaryTreeNode<T> : Node<T>
    {
        #region [Constrcutor]
        /// <summary>
        /// Create a node of binary tree
        /// </summary>
        public BinaryTreeNode() : base() { }

        /// <summary>
        /// Craete a node of binary tree
        /// </summary>
        /// <param name="data">Value of the binary tree</param>
        public BinaryTreeNode(T data) : base(data, null) { }

        /// <summary>
        /// Craete a node of binary tree
        /// </summary>
        /// <param name="data">Value of the binary tree</param>
        /// <param name="left">Left child of binary tree</param>
        /// <param name="right">Right child of binary tree</param>
        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {            
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;
            base.Value = data;
            base.Neighbours = children;
        }
        #endregion

        #region [Properties]
        /// <summary>
        /// Left child of the node
        /// </summary>
        public BinaryTreeNode<T> Left
        {
            get
            {
                if (base.Neighbours == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbours[0];
            }
            set 
            {
                if (base.Neighbours == null)
                    base.Neighbours = new NodeList<T>(2);

                base.Neighbours[0] = value;
            }
        }

        /// <summary>
        /// Right child of the node
        /// </summary>
        public BinaryTreeNode<T> Right
        {
            get
            {
                if (base.Neighbours == null)
                    return null;
                else
                    return (BinaryTreeNode<T>)base.Neighbours[1];
            }
            set
            {
                if (base.Neighbours == null)
                    base.Neighbours = new NodeList<T>(2);

                base.Neighbours[1] = value;
            }
        }
        #endregion
    }

}
