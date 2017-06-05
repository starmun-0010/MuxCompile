using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Common
{
    public interface IGrammer
    {
        string StartSymbol { get; }
        List<Production> Productions { get; }
        Task Initialize();
        List<string> NonTerminals { get; }
        List<string> Terminals { get; }

        List<string> Symbols { get; }

        List<Item> Items { get; }

        List<string> Follow(string nonTerminal);
    }
}