using System;
using System.Collections.Generic;
using System.Linq;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;
using AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator.Infrastructure;

namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator
{
    public class SLRParserGenerator : ILRParserGenerator
    {
        private IGrammer _grammer;

        public SLRParserGenerator(IGrammer grammer)
        {
            _grammer = grammer;
        }

        public List<List<Item>> LR0Automaton { get; set; }


        private void ComputeLR0Automaton()
        {
            var closures = new List<List<Item>>();
            var newClosures = new List<List<Item>>();
            var itemsList = new List<Item>() { _grammer.Items.First() };
            closures.Add(Closure(itemsList));
            var isAnyNewItemSetInserted = false;

            do
            {
                isAnyNewItemSetInserted = false;
                foreach (var itemSet in closures)
                {
                    foreach (var symbol in _grammer.Symbols)
                    {
                        var nextItemSet = GoTo(itemSet, symbol);
                        if (nextItemSet.kernelItems.Count > 0 && !closures.Contains(nextItemSet.kernelItems, new CustomListOfItemComparer()))
                        {
                            newClosures.Add(nextItemSet.AllItems);

                            isAnyNewItemSetInserted = true;

                        }
                    }
                }

                closures.AddRange(newClosures);
                newClosures.Clear();
            } while (isAnyNewItemSetInserted);


            LR0Automaton = closures;

            List<Item> Closure(List<Item> itemsSet)
            {

                //already closured non terminals
                var insertedSymbols = new List<string>();
                var newItems = new List<Item>();

                //any item changed in this go?

                var isDirty = false;


                do
                {
                    isDirty = false;

                    foreach (var item in itemsSet)
                    {

                        //if item ends at "." then no more items to insert. so if item does not end at "." then proceed ahead
                        if (item.Rule.Last() != ".")
                        {
                            (var symbol, var index) = GetNextSymnbol(item);
                            //if the symbol is not a terminal (i.e. is a non terminal) 
                            //and the productions for this non are not already inserted in current set then
                            if (!_grammer.Terminals.Contains(item.Rule[index]) && !insertedSymbols.Contains(symbol))
                            {
                                //add all productions for the non terminal to the items set as new items
                                foreach (var production in _grammer.Productions)
                                {
                                    if (production.NonTerminal == symbol)
                                    {
                                        var newItem = new Item() { NonTerminal = production.NonTerminal, Rule = new List<string>() };
                                        newItem.Rule.Add(".");
                                        newItem.Rule.AddRange(production.Rule);

                                        if (!itemsSet.Contains(newItem, new CustomItemComparer()))
                                        {
                                            newItems.Add(newItem);

                                            isDirty = true;
                                        }

                                    }
                                }
                                insertedSymbols.Add(symbol);
                            }
                        }
                    }
                    itemsSet.AddRange(newItems);
                    newItems.Clear();

                } while (isDirty);

                return itemsSet;




                (string symbol, int index) GetNextSymnbol(Item item)
                {
                    var index = item.Rule.IndexOf(".");

                    return (item.Rule[index + 1], index);
                }
            }

            (List<Item> kernelItems, List<Item> AllItems) GoTo(List<Item> itemSet, string symbol)
            {
                var newItemSet = new List<Item>();
                var kernelItems = new List<Item>();

                foreach (var item in itemSet)
                {

                    var indexOfDot = item.Rule.IndexOf(".");
                    if (indexOfDot != item.Rule.Count - 1 && item.Rule[indexOfDot + 1] == symbol)
                    {
                        var newItem = new Item() { NonTerminal = item.NonTerminal, Rule = new List<string>() };
                        newItem.Rule.AddRange(item.Rule.GetRange(0, indexOfDot));
                        newItem.Rule.AddRange(item.Rule.GetRange(indexOfDot + 1, 1));

                        newItem.Rule.Add(".");

                        newItem.Rule.AddRange(item.Rule.GetRange(indexOfDot + 2, item.Rule.Count - indexOfDot - 2));
                        kernelItems.Add(newItem);
                    }


                }

                newItemSet.AddRange(Closure(kernelItems));


                return (kernelItems, newItemSet);
            }
        }



        public ILRParseTable GenerateParser()
        {

            ComputeLR0Automaton();


            throw new NotImplementedException();
        }


    }
}