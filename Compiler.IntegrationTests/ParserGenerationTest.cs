using System;
using System.IO;
using Compiler.Common;
using Compiler.ParserGenerator;
using Xunit;

namespace IntegrationTests
{
    public class ParserGenerationTest
    {
        [Fact]
        public void TestParserGeneration()
        {
            var text = File.ReadAllText(
               $@"{Path.Combine($@"{Directory.GetCurrentDirectory()}", @"../../../../")}\Expression Grammer.json");
            IGrammarReader reader = new JsonGrammerReader();
            IGrammar grammar = reader.Read(text);
            grammar.Initialize();

            var parserGenerator = new SLRParserGenerator(grammar);


            var parseTable = parserGenerator.GenerateParser();
            Assert.Equal(parseTable.Action[0]["id"], (Compiler.Common.Action.Shift, 5));
        }
    }
}
