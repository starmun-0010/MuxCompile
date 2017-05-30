using System;
using System.Collections.Generic;
using System.Text;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Lexer
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
