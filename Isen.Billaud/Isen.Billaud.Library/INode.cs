using System;
using System.Collections.Generic;

namespace Isen.Billaud.Library
{
    public interface INode

    {
        String Value { get; set; }
        
        Guid Id { get; }
        
        INode Parent { get; set; }

        INode ChildAt(int index);

        INode AddChild(INode child);
        
        
        int Depth { get; }
        
        
    }
}