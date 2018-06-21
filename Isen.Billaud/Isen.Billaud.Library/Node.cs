using System;
using System.Collections.Generic;

namespace Isen.Billaud.Library
{
    public class Node : INode<Node>,IEquatable<Node>
    {
        private string _value;
        private readonly List<Node> _children;


        public Node(string value, Node parent = null)
        {
            Id = Guid.NewGuid();
            _children= new List<Node>(5);
            _value = value;
            //Mets aussi jour la profondeur en fonction de la profondeur du parents
            parent?.AddChildNode(this);
        }


        public Node ChildAt(int index)
        {
            return _children[index];
        }

        public void AddChildNode(Node child)
        {
            _children.Add(child);
            child.Parent = this;
        }

        public void AddNodes(IEnumerable<Node> nodeList)
        {
            foreach (Node node in nodeList)
            {
                this.AddChildNode(node);
            }
        }

        public void RemoveChildNode(Guid id)
        {
            _children.ForEach((node =>
            {
                if (node.Id != id) return;
                node.Parent = null;
                _children.Remove(node);
            }));
        }

        public void RemoveChildNode(Node node)
        {
            _children.ForEach((enfant) =>
            {
                //List.remove fait déjà appel à Equals, vu que IEquatable est implementé
                //Mais le sujet demande d'utilisé Equals();
                if (Equals(node, enfant))
                {
                    _children.Remove(enfant);
                }
            });
        }

        public int Depth => Parent?.Depth + 1 ?? 0;


        public string Value
        {
            get => _value; 
            set => _value=value;
        }
        public Guid Id { get; }

        public Node Parent { get; set; }

        #region equals
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
        

        #endregion

        
        public override string ToString()
        {
            return $"id : {Id}, Value : {Value} , profondeur : {Depth}, nombre d'enfant : {_children.Count} ";
        }
        
    }
}