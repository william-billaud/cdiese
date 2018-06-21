using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Isen.Billaud.Library
{
    public interface INode<T> : IEquatable<INode<T>>

    {
        T Value { get; set; }

        Guid Id { get; }

        INode<T> Parent { get; set; }

        int Depth { get; }

        INode<T> ChildAt(int index);

        #region Question3

        void AddChildNode(INode<T> child);

        void AddNodes(IEnumerable<INode<T>> nodeList);

        void RemoveChildNode(Guid id);

        void RemoveChildNode(INode<T> node);

        #endregion


        #region Question4

        INode<T> FindTraversing(Guid id);

        INode<T> FindTraversing(INode<T> node);

        #endregion

        #region Question6
        
        JObject SerializeJSon();

        void UnserializeJson(JToken jobj);


        #endregion
    }
    
}