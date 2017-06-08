using System;
using System.Collections.Generic;
using System.Text;
using Compiler.Common;
using Moq;
using Xunit;

namespace Compiler.ParserGenerator.Tests
{
    public class SLRParserGeneratorTests : IClassFixture<GrammarFixture>
    {
        private GrammarFixture _fixture;

        public SLRParserGeneratorTests(GrammarFixture fixture)
        {
            _fixture = fixture;
        }
        //[Fact]
        //public void ShouldGenerateAccuratreParseTable()
        //{
        //    //arrange


        //    var parserGenerator = new SLRParserGenerator(_fixture.Grammar);


        //    //act 


        //    var parseTable = parserGenerator.GenerateParser();


        //    Assert.Equal(parseTable.Action[0]["id"], (Common.Action.Shift, 5));

        //}
    }
}
