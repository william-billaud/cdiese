using System;
using System.Collections.Generic;

namespace Isen.Billaud.Library
{
    public class Node : INode<Node>,IEquatable<Node>
    {
        private string _value;
        private List<Node> _children;


        public Node(string value, Node parent = null)
        {
            Id = Guid.NewGuid();
            _value = value;
            Parent = parent;
            _children= new List<Node>(5);
            Depth = parent?.Depth + 1 ?? 0;
            parent?.AddChild(this);
        }


        public Node ChildAt(int index)
        {
            return _children[index];
        }

        public Node AddChild(Node child)
        {
            _children.Add(child);
            return this;
        }

        public int Depth { get; }


        public string Value
        {
            get => _value; 
            set => _value=value;
        }
        public Guid Id { get; }

        public Node Parent { get; set; }


        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_value, other._value) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_value != null ? _value.GetHashCode() : 0) * 397) ^ Id.GetHashCode();
            }
        }
        
        public override string ToString()
        {
            return $"id : {Id}, Value : {Value} , profondeur : {Depth}, nombre d'enfant : {_children.Count} ";
        }
        
    }
}