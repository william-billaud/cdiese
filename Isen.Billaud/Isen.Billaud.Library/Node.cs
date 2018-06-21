using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Isen.Billaud.Library
{
    public class Node<T> : INode<T>
    {
        private readonly List<INode<T>> _children;


        public Node(T value = default(T), Node<T> parent = null)
        {
            Id = Guid.NewGuid();
            _children = new List<INode<T>>(5);
            Value = value;
            parent?.AddChildNode(this);
        }

        public int Depth => Parent?.Depth + 1 ?? 0;
        public Guid Id { get; }

        public T Value { get; set; }

        public INode<T> Parent { get; set; }

        public INode<T> ChildAt(int index)
        {
            return _children[index];
        }

        #region Question3

        public void AddChildNode(INode<T> child)
        {
            _children.Add(child);
            child.Parent = this;
        }

        public void AddNodes(IEnumerable<INode<T>> nodeList)
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

        public void RemoveChildNode(INode<T> node)
        {
            _children.ToList().ForEach(enfant =>
            {
                if (!Equals(node, enfant)) return;
                _children.Remove(enfant);
                enfant.Parent = null;
            });
        }

        #endregion

        #region Question4

        public INode<T> FindTraversing(Guid id)

        {
            if (Id == id) return this;

            foreach (var enfant in _children)

            {
                var res = enfant.FindTraversing(id);

                if (res != null) return res;
            }


            return null;
        }


        public INode<T> FindTraversing(INode<T> node)

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

        #region Question7

        public JObject SerializeJSon()

        {
            var jobj = new JObject();

            jobj.Add(new JProperty("value", Value));

            var jarr = new JArray();
            _children.ForEach((node) => { jarr.Add(node.SerializeJSon()); });

            jobj.Add(new JProperty("enfants", jarr));


            return jobj;
        }


        public void UnserializeJson(JToken jobj)

        {
            Value = jobj["value"].ToObject<T>();

            var childs = jobj["enfants"]?.Children().ToList();
            foreach (var jTok in childs)
            {
                var nodeEnfant = new Node<T>();

                nodeEnfant.UnserializeJson(jTok);
                AddChildNode(nodeEnfant);
            }
        }

        #endregion

        #region equals

        public bool Equals(INode<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Value, other.Value) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Node<T>) obj);
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