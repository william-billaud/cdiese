﻿using System;
using System.Collections.Generic;

namespace Isen.Billaud.Library
{
    public interface INode

    {
        String Value { get; set; }
        
        Guid Id { get; }
        
        INode Parent { get; set; }

        INode ChildAt(int index);

        int Depth { get; }
        
        void AddChildNode(INode child);

        void AddNodes(IEnumerable<INode> nodeList);

        void RemoveChildNode(Guid id);

        void RemoveChildNode(INode node);





    }
}