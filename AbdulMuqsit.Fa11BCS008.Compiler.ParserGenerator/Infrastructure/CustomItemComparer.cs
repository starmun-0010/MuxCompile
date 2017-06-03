using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;

namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator.Infrastructure
{
    public class CustomItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            return x.NonTerminal == y.NonTerminal && x.Rule.SequenceEqual(y.Rule);
        }

        public int GetHashCode(Item obj)
        {
            return obj.GetHashCode();
        }
    }
}
