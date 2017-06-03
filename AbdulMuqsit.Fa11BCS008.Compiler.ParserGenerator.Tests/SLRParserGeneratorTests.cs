using System;
using System.Collections.Generic;
using System.Text;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;
using Moq;
using Xunit;

namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator.Tests
{
    public class SLRParserGeneratorTests
    {
        [Fact]
        public void ShouldGenerateAccuratreParseTable()
        {
            //arrange

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

            var mockGrammer = new Mock<IGrammer>();


            mockGrammer.Setup(g => g.Productions).Returns(productions);
            mockGrammer.Setup(g => g.Symbols).Returns(symbols);
            mockGrammer.Setup(g => g.Terminals).Returns(terminals);

            mockGrammer.Setup(g => g.NonTerminals).Returns(nonTerminals);
            mockGrammer.Setup(g => g.Items).Returns(items);

            mockGrammer.Setup(g => g.StartSymbol).Returns("E`");

            var parserGenerator = new SLRParserGenerator(mockGrammer.Object);


            //act 


            parserGenerator.GenerateParser();

        }
    }
}
