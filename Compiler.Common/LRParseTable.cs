using System.Collections.Generic;

namespace Compiler.Common
{
    public class LRParseTable
    {
        public Dictionary<int, Dictionary<string, (Action action, int? reference)>> Action { get; } = new Dictionary<int, Dictionary<string, (Common.Action action, int? reference)>>();
        public Dictionary<int, Dictionary<string, int>> GoTo { get; } = new Dictionary<int, Dictionary<string, int>>();
    }
}