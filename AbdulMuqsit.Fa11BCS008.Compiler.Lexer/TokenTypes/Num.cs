namespace AbdulMuqsit.Fa11BCS008.Compiler.Lexer
{
    internal class Num : Token
    {
        private string value;

        public Num(string value) : base(Common.Tag.NUM)
        {
            this.value = value;
        }
    }
}