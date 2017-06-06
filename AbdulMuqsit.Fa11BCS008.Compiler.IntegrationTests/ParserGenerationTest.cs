using System;
using System.IO;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;
using AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator;
using Xunit;

namespace AbdulMuqsit.Fa11BCS008.Compiler.IntegrationTests
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
            Assert.Equal(parseTable.Action[0]["id"], (Common.Action.Shift, 5));
        }
    }
}
