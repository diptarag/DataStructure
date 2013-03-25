using System;

namespace DataStructures.Tree.BinaryTree
{
    /// <summary>
    /// Custom exception handling class for Binary Tree
    /// </summary>
    class BinaryTreeException : Exception
    {
        public BinaryTreeException() : base() { }
        public BinaryTreeException(string message) : base(message) { }
        public BinaryTreeException(string message, Exception innerException) : base(message, innerException) { }
        public BinaryTreeException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
