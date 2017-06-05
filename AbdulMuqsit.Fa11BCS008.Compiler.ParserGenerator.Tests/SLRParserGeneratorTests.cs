using System;
using System.Collections.Generic;
using System.Text;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;
using Moq;
using Xunit;

namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator.Tests
{
    public class SLRParserGeneratorTests : IClassFixture<GrammarFixture>
    {
        private GrammarFixture _fixture;

        public SLRParserGeneratorTests(GrammarFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void ShouldGenerateAccuratreParseTable()
        {
            //arrange


            var parserGenerator = new SLRParserGenerator(_fixture.Grammar);


            //act 


            var parseTable = parserGenerator.GenerateParser();


            Assert.Equal(parseTable.Action[0]["id"], (Common.Action.Shift, 5));

        }
    }
}
