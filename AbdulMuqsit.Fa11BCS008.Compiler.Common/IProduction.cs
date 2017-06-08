using System;
using System.Collections.Generic;

namespace Compiler.Common
{
    public class Production
    {
        public string NonTerminal { get; set; }
        public List<string> Rule { get; set; }

        public override string ToString()
        {
            return $"{NonTerminal} ==> {String.Join("", Rule.ToArray())}";
        }
    }
}