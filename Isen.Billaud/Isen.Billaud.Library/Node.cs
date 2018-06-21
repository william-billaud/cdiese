using System;
using System.Collections.Generic;
using System.Linq;

namespace Isen.Billaud.Library
{
    public class Node : INode,IEquatable<Node>
    {
        private readonly List<INode> _children;


        public Node(string value, Node parent = null)
        {
            Id = Guid.NewGuid();
            _children= new List<INode>(5);
            Value = value;
            parent?.AddChildNode(this);
        }


        public INode ChildAt(int index)
        {
            return _children[index];
        }

        public void AddChildNode(INode child)
        {
            _children.Add(child);
            child.Parent = this;
        }

        public void AddNodes(IEnumerable<INode> nodeList)
        {
            foreach (var node in nodeList.ToList())
            {
                AddChildNode(node);
            }
        }

        public void RemoveChildNode(Guid id)
        {
            _children.ToList().ForEach((node =>
            {
                if (node.Id != id) return;
                node.Parent = null;
                _children.Remove(node);
            }));
        }

        public string Value { get; set; }

        public void RemoveChildNode(INode node)
        {
            _children.ToList().ForEach((enfant) =>
            {
                //List.remove fait déjà appel à Equals, vu que IEquatable est implementé
                //Mais le sujet demande d'utilisé Equals();
                if (Equals(node, enfant))
                {
                    _children.Remove(enfant);
                    enfant.Parent = null;
                }
            });
        }
        public int Depth => Parent?.Depth + 1 ?? 0;
        public Guid Id { get; }

        public INode Parent { get; set; }

        #region equals
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
            return obj.GetType() == GetType() && Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ Id.GetHashCode();
            }
        }
        

        #endregion

        
        public override string ToString()
        {
            return $"id : {Id}, Value : {Value} , profondeur : {Depth}, nombre d'enfant : {_children.Count} ";
        }
        
    }
}