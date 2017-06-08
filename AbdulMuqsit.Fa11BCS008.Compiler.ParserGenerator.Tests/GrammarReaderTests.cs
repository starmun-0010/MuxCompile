using System;
using System.IO;
using Compiler.Common;
using Xunit;
using System.Linq;
namespace Compiler.ParserGenerator.Tests
{
    public class GrammarReaderTests
    {
        [Fact]
        public void CallingReadGrammerShouldReturnIGrammerObject()
        {
            var text = File.ReadAllText(
                $@"{Path.Combine($@"{Directory.GetCurrentDirectory()}", @"../../../../")}\Expression Grammer.json");
            IGrammarReader reader = new JsonGrammerReader();
            IGrammar grammer = reader.Read(text);
            grammer.Initialize();
            Assert.NotNull(grammer);
            Assert.Equal(((Grammar)grammer).Productions.Last().Rule.First(), "id");
            Assert.True(grammer.Symbols.Contains("id"));
            Assert.False(grammer.Terminals.Contains("E"));
        }
    }
}
