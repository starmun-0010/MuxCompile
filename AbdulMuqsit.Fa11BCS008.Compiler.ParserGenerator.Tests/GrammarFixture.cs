using System;
using System.Collections.Generic;
using System.Text;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;
using Moq;

namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator.Tests
{
    public class GrammarFixture : IDisposable
    {
        public GrammarFixture()
        {
            var productions = new List<Production>() {
                new Production{ NonTerminal="E`", Rule = new List<string> {"E"} },
                new Production{ NonTerminal="E", Rule = new List<string> { "E", "+", "T"  } },
                new Production{ NonTerminal="E", Rule = new List<string> { "T" } },
                new Production{ NonTerminal="T", Rule = new List<string>  { "T", "*", "F" } },
                new Production{ NonTerminal="T", Rule = new List<string>  {"F" } },
                new Production{ NonTerminal="F", Rule = new List<string>  { "(", "E", ")" } },
                new Production{ NonTerminal="F", Rule = new List<string> {"id" } }

            };

            var symbols = new List<string>()
            {
                "E`",
                "E",
                "+",
                "T",
                "*",
                "F",
                "(",
                ")",
                "id"

            };

            var terminals = new List<string>()
            {

                "+",
                "*",
                "(",
                ")",
                "id"

            };

            var nonTerminals = new List<string>()
            {

                "E`",
                "E",
                "T",
                "F",

            };

            var items = new List<Item>
            {
                //E`=>E
                new Item{ NonTerminal="E`", Rule = new List<string> {".", "E"} },
                new Item{ NonTerminal="E`", Rule = new List<string> {"E", "."} },


                //E=> E+T
                new Item{ NonTerminal="E", Rule = new List<string> { ".", "E", "+", "T"  } },
                new Item{ NonTerminal="E", Rule = new List<string> { "E", ".", "+", "T"  } },
                new Item{ NonTerminal="E", Rule = new List<string> { "E", "+", ".", "T"  } },
                new Item{ NonTerminal="E", Rule = new List<string> { "E", "+", "T", "." } },
                                                 
                //E=>E                           
                new Item{ NonTerminal="E", Rule = new List<string> { ".", "T" } },
                new Item{ NonTerminal="E", Rule = new List<string> { "T", "."} },
                                                   
                //T=>T*F                           
                new Item{ NonTerminal="T", Rule = new List<string> { ".", "T", "*", "F" } },
                new Item{ NonTerminal="T", Rule = new List<string> { "T", ".", "*", "F" } },
                new Item{ NonTerminal="T", Rule = new List<string> { "T", "*", ".", "F" } },
                new Item{ NonTerminal="T", Rule = new List<string> { "T", "*", "F", "."} },
                                                 
                //T=>F                            
                new Item{ NonTerminal="T", Rule = new List<string> { ".", "F" } },
                new Item{ NonTerminal="T", Rule = new List<string> { "F", "." } },
                                                  
                //F=>(E)                          
                new Item{ NonTerminal="F", Rule = new List<string> { ".", "(", "E", ")" } },
                new Item{ NonTerminal="F", Rule = new List<string> { "(", ".", "E", ")" } },
                new Item{ NonTerminal="F", Rule = new List<string> { "(", "E", ".", ")" } },
                new Item{ NonTerminal="F", Rule = new List<string> { "(", "E", ")", "."} },
                                                 
                //F=>id                          
                new Item{ NonTerminal="F", Rule = new List<string> {".", "id"} },
                new Item{ NonTerminal="F", Rule = new List<string> {"id", "." } }

            };

            var mockGrammar = new Mock<IGrammar>();




            mockGrammar.Setup(g => g.Productions).Returns(productions);
            mockGrammar.Setup(g => g.Symbols).Returns(symbols);
            mockGrammar.Setup(g => g.Terminals).Returns(terminals);

            mockGrammar.Setup(g => g.NonTerminals).Returns(nonTerminals);
            mockGrammar.Setup(g => g.Items).Returns(items);

            mockGrammar.Setup(g => g.StartSymbol).Returns("E`");

            mockGrammar.Setup(g => g.Follow("E")).Returns(new List<string>() { "", "", "" });

            Grammar = mockGrammar.Object;

        }

        public IGrammar Grammar { get; private set; }

        public void Dispose()
        {
        }
    }
}
