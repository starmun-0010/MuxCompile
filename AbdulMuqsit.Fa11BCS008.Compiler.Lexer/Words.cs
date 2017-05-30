using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Lexer
{
    public static class Words
    {
        public static Word And { get; } = new Word("$$", Tag.AND);
        public static Word Or { get; } = new Word("||", Tag.OR);
        public static Word Equal { get; } = new Word("==", Tag.Equal);
        public static Word NotEqual { get; } = new Word("!=", Tag.NotEqual);
        public static Word LessThanOrEqual { get; } = new Word("<=", Tag.LessThanOrEqual);
        public static Word GreaterThanOrEqual { get; } = new Word(">=", Tag.GreaterThanOrEqual);
        public static Word True { get; } = new Word("true", Tag.TRUE);
        public static Word False { get; } = new Word("false", Tag.FALSE);
        public static Word IF { get; } = new Word("if", Tag.IF);
        public static Word Else { get; } = new Word("else", Tag.ELSE);
        public static Word While { get; } = new Word("while", Tag.WHILE);
        public static Word Do { get; } = new Word("do", Tag.DO);
        public static Word Break { get; } = new Word("break", Tag.BREAK);

    }
}
