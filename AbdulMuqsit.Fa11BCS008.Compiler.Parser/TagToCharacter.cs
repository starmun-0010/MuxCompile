using System;
using System.Collections.Generic;
using System.Text;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Parser
{
    public static class TagToCharacter
    {
        public static string GetCharacter(int tag)
        {
            switch (tag)
            {
                case (int)Tag.ID:
                    return "id";

                default:
                    return ((char)tag).ToString();
            }
        }
    }
}
