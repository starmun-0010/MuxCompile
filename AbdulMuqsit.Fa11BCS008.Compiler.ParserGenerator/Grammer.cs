using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;

namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator
{
    public class Grammer : IGrammer
    {
        public string StartSymbol => Productions.FirstOrDefault()?.NonTerminal;
        public List<Production> Productions { get; set; }

        public List<string> NonTerminals { get; private set; }
        public List<string> Terminals { get; private set; }

        public List<string> Symbols { get; set; }

        public List<Item> Items { get; set; }

        public List<string> Follow(string nonTerminal)
        {
            throw new NotImplementedException();
        }

        public Task Initialize()
        {
            InitializeSymbols();
            InitializeNonTerminals();
            InitializeTerminals();
            InitializeItems();


            void InitializeNonTerminals()
            {
                var nonTerminals = new List<string>();
                foreach (var production in Productions)
                {
                    if (!nonTerminals.Contains(production.NonTerminal))
                    {
                        nonTerminals.Add(production.NonTerminal);
                    }
                }
                NonTerminals = nonTerminals;
            }
            void InitializeTerminals()
            {
                var terminals = new List<string>();
                foreach (var production in Productions)
                {
                    foreach (var symbol in production.Rule)
                    {
                        if (!NonTerminals.Contains(symbol) && !terminals.Contains(symbol))
                        {
                            terminals.Add(symbol);
                        }
                    }
                }
                Terminals = terminals;
            }

            void InitializeFirstSet(List<string> symbols)
            {
                throw new NotImplementedException();
            }
            void InitializeFollowSet(List<string> symbols)
            {
                throw new NotImplementedException();
            }

            void InitializeItems()
            {
                var items = new List<Item>();
                foreach (var production in Productions)
                {


                    for (int i = 0; i < production.Rule.Count + 1; i++)
                    {
                        var item = new Item() { NonTerminal = production.NonTerminal, Rule = new List<string>() };
                        item.Rule.AddRange(production.Rule.GetRange(0, i));
                        item.Rule.Add(".");
                        item.Rule.AddRange(production.Rule.GetRange(i, production.Rule.Count - i));

                        items.Add(item);
                    }
                }
                Items = items;
            }


            void InitializeSymbols()
            {
                var symbols = new List<string>();
                foreach (var production in Productions)
                {
                    if (!symbols.Contains(production.NonTerminal))
                    {
                        symbols.Add(production.NonTerminal);
                    }
                    foreach (var symbol in production.Rule)
                    {
                        if (!symbols.Contains(symbol))
                        {
                            symbols.Add(symbol);
                        }
                    }
                }
                Symbols = symbols;
            }
            return Task.FromResult(0);
        }
    }
}
