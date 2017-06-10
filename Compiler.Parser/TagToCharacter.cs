using System;
using System.Collections.Generic;
using System.Text;
using Compiler.Common;

namespace Compiler.Parser
{
    public static class TagToCharacter
    {
        public static string GetCharacter(int tag)
        {
            switch (tag)
            {
                case (int)Tag.ID:
                    return "id";
                case (int)Tag.End:
                    return "$";
                default:
                    return ((char)tag).ToString();
            }
        }
    }
}
