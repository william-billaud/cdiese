using System;
using System.Collections.Generic;

namespace Isen.Billaud.Library
{
    public class Node : INode,IEquatable<Node>
    {
        private List<INode> _children;


        public Node(string value, Node parent = null)
        {
            Id = Guid.NewGuid();
            Value = value;
            Parent = parent;
            _children= new List<INode>(5);
            Depth = parent?.Depth + 1 ?? 0;
            parent?.AddChild(this);
        }


        public INode ChildAt(int index)
        {
            return _children[index];
        }

        public INode AddChild(INode child)
        {
            _children.Add(child);
            return this;
        }

        public int Depth { get; }


        public string Value { get; set; }

        public Guid Id { get; }

        public INode Parent { get; set; }


        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ Id.GetHashCode();
            }
        }
        
        public override string ToString()
        {
            return $"id : {Id}, Value : {Value} , profondeur : {Depth}, nombre d'enfant : {_children.Count} ";
        }
        
    }
}