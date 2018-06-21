using System;
using System.Collections.Generic;
using System.Linq;

namespace Isen.Billaud.Library
{
    public class Node : INode, IEquatable<Node>
    {
        private readonly List<INode> _children;


        public Node(string value, Node parent = null)
        {
            Id = Guid.NewGuid();
            _children = new List<INode>(5);
            Value = value;
            parent?.AddChildNode(this);
        }

        public int Depth => Parent?.Depth + 1 ?? 0;
        public Guid Id { get; }

        public INode Parent { get; set; }

        public INode ChildAt(int index)
        {
            return _children[index];
        }

        #region Question3

        public void AddChildNode(INode child)
        {
            _children.Add(child);
            child.Parent = this;
        }

        public void AddNodes(IEnumerable<INode> nodeList)
        {
            foreach (var node in nodeList.ToList()) AddChildNode(node);
        }

        public void RemoveChildNode(Guid id)
        {
            _children.ToList().ForEach(node =>
            {
                if (node.Id != id) return;
                node.Parent = null;
                _children.Remove(node);
            });
        }

        public string Value { get; set; }

        public void RemoveChildNode(INode node)
        {
            _children.ToList().ForEach(enfant =>
            {
                if (Equals(node, enfant))
                {
                    _children.Remove(enfant);
                    enfant.Parent = null;
                }
            });
        }

        #endregion

        #region Question4

        public INode FindTraversing(Guid id)

        {
            if (Id == id) return this;

            foreach (var enfant in _children)

            {
                var res = enfant.FindTraversing(id);

                if (res != null) return res;
            }


            return null;
        }


        public INode FindTraversing(INode node)

        {
            if (Equals(node)) return this;

            foreach (var enfant in _children)

            {
                var res = enfant.FindTraversing(node);

                if (res != null) return res;
            }


            return null;
        }

        #endregion

        #region Question5

        public override string ToString()
        {
            String retour = "";

            for (var i = 0; i < this.Depth; i++)

            {
                retour += "|-";
            }

            retour += $"{Value}  {Id}";

            foreach (var child in _children)

            {
                retour += Environment.NewLine + child.ToString();
            }


            return retour;
        }

        #endregion

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
    }
}