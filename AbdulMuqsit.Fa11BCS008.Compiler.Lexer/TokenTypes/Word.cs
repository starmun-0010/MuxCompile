using System;
using System.Collections.Generic;
using System.Text;
using Compiler.Common;

namespace Compiler.Lexer
{
    public class Word : Token
    {
        public string Lexeme { get; private set; }

        public Word(string lexeme, Tag tag) : base(tag) => Lexeme = lexeme;
        public override string ToString()
        {
            return Lexeme;
        }
    }
}
