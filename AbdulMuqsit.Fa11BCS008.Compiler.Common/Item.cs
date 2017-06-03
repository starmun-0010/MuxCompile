using System.Collections.Generic;
using System.Linq;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Common
{
    public class Item : Production
    {


        public static bool operator ==(Item x, Item y)
        {
            return x.NonTerminal == y.NonTerminal && x.Rule.SequenceEqual(y.Rule);

        }
        public static bool operator !=(Item x, Item y)
        {
            return x.NonTerminal != y.NonTerminal || !x.Rule.SequenceEqual(y.Rule);

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}