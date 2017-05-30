using AbdulMuqsit.Fa11BCS008.Compiler.Lexer.Contracts;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Lexer
{
    public class Token : IToken
    {

        /* one for each keyword
*
* can be set can be one for each operator
* 
* one for all identifiers
* 
* one or more for constants, (numbers, literal strings)
* 
* one for each punctuation symbol ({}(),;)
*
* */
        public int Tag { get; set; }

        public Token(int t) => Tag = t;

        public Token(Tag tag)
        {
            Tag = (int)tag;
        }
    }
}