using System;
using System.IO;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;
using Xunit;
using System.Linq;
namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator.Tests
{
    public class GrammerReaderTests
    {
        [Fact]
        public void CallingReadGrammerShouldReturnIGrammerObject()
        {
            var text = File.ReadAllText(
                $@"{Path.Combine($@"{Directory.GetCurrentDirectory()}", @"../../../../")}\Expression Grammer.json");
            IGrammerReader reader = new JsonGrammerReader();
            IGrammer grammer = reader.Read(text);
            grammer.Initialize();
            Assert.NotNull(grammer);
            Assert.Equal(((Grammer)grammer).Productions.Last().Rule.First(), "id");
            Assert.True(grammer.Symbols.Contains("id"));
            Assert.False(grammer.Terminals.Contains("E"));
        }
    }
}
