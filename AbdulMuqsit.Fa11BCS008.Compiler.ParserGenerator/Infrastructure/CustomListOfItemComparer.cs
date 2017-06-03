using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;

namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator.Infrastructure
{
    public class CustomListOfItemComparer : IEqualityComparer<List<Item>>
    {
        public bool Equals(List<Item> x, List<Item> y)
        {
            for (int i = 0; i < y.Count; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }

            }
            return true;
        }

        public int GetHashCode(List<Item> obj)
        {
            return obj.GetHashCode();
        }
    }
}
