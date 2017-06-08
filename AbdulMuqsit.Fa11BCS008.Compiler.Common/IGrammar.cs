using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compiler.Common
{
    public interface IGrammar
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