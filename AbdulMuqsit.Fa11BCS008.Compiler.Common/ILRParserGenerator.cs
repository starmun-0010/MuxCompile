using System;
using System.Collections.Generic;
using System.Text;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Common
{
    public interface ILRParserGenerator
    {
        LRParseTable GenerateParser();
    }
}
