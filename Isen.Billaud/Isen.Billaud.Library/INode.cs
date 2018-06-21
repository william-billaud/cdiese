using System;
using System.Collections.Generic;

namespace Isen.Billaud.Library
{
    public interface INode<T> where T:INode<T>

    {
        String Value { get; set; }
        
        Guid Id { get; }
        
        T Parent { get; set; }

        T ChildAt(int index);

        T AddChild(T child);
        
        
        int Depth { get; }
        
        
    }
}