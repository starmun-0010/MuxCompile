using System;
using System.Collections.Generic;
using System.Text;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Lexer
{
    public static class Types
    {
        public static Word Int { get; } = new Word("int", Common.Tag.BASIC);
        public static Word Char { get; } = new Word("char", Common.Tag.BASIC);
        public static Word Float { get; } = new Word("float", Common.Tag.BASIC);
        public static Word Bool { get; } = new Word("bool", Common.Tag.BASIC);

    }
}
