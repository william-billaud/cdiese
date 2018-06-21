using System;
using System.Collections.Generic;

namespace Isen.Billaud.Library
{
    public interface INode

    {
        string Value { get; set; }

        Guid Id { get; }

        INode Parent { get; set; }

        int Depth { get; }

        INode ChildAt(int index);

        #region Question3

        void AddChildNode(INode child);

        void AddNodes(IEnumerable<INode> nodeList);

        void RemoveChildNode(Guid id);

        void RemoveChildNode(INode node);

        #endregion


        #region Question4

        INode FindTraversing(Guid id);

        INode FindTraversing(INode node);

        #endregion
    }
}