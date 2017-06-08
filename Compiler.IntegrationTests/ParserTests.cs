using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Compiler.Common;
using Compiler.Lexer;
using Compiler.Parser;
using Compiler.ParserGenerator;
using Moq;
using Xunit;

namespace IntegrationTests
{
    public class ParserTests
    {
        [Fact]
        public void ShouldParseExpressionInput()
        {
            var text = File.ReadAllText(
              $@"{Path.Combine($@"{Directory.GetCurrentDirectory()}", @"../../../../")}\Expression Grammer.json");
            IGrammarReader reader = new JsonGrammerReader();
            IGrammar grammar = reader.Read(text);
            grammar.Initialize();
            var outPuts = new List<string>();
            var parserGenerator = new SLRParserGenerator(grammar);
            var input = "k + k";

            var lexer = new Lexer(input);

            var parseTable = parserGenerator.GenerateParser();

            var mockOutSource = new Mock<IOutSource>();
            mockOutSource.Setup(os => os.WriteLine(It.IsAny<string>())).Callback<string>(s =>
            {
                Console.WriteLine(s);
                Debug.WriteLine(s);

                outPuts.Add(s);
            });

            var parser = new LRParser();

            parser.Parse(parseTable, lexer, grammar, mockOutSource.Object);

            Assert.Equal("Successfully Parsed", outPuts.Last());

        }
    }
}
