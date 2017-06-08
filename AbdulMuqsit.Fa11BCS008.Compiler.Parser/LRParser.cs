using System;
using System.Collections.Generic;
using System.Text;
using Compiler.Common;

namespace Compiler.Parser
{
    public class LRParser
    {

        public void Parse(LRParseTable parseTable, ILexer lexer, IGrammar grammar, IOutSource outSource)
        {
            var token = lexer.GetNextToken();
            var stack = new Stack<int>();
            (Common.Action action, int? reference) action;
            stack.Push(0);
            int topState;

            do
            {
                topState = stack.Peek();
                action = parseTable.Action[topState][TagToCharacter.GetCharacter(token.Tag)];
                if (action.action == Common.Action.Shift)
                {
                    stack.Push(action.reference.Value);
                    token = lexer.GetNextToken();
                }
                else if (action.action == Common.Action.Reduce)
                {
                    var production = grammar.Productions[action.reference.Value];
                    foreach (var item in production.Rule)
                    {
                        stack.Pop();
                        topState = stack.Peek();
                        stack.Push(parseTable.GoTo[topState][production.NonTerminal]);
                        outSource.WriteLine(production.ToString());
                    }
                }
                else if (action.action == Common.Action.Accept)
                {
                    outSource.WriteLine("Successfully Parsed");
                }
                else if (action.action == Common.Action.Error)
                {
                    outSource.WriteLine("Error");
                }

            } while (action.action != Common.Action.Accept && action.action != Common.Action.Error);

        }
    }
}
