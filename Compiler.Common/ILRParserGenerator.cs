using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Common
{
    public interface ILRParserGenerator
    {
        LRParseTable GenerateParser();
    }
}
