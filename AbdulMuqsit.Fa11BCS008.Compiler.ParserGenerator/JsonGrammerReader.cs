using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AbdulMuqsit.Fa11BCS008.Compiler.Common;
using Newtonsoft.Json;

namespace AbdulMuqsit.Fa11BCS008.Compiler.ParserGenerator
{
    public class JsonGrammerReader : IGrammarReader
    {
        public IGrammar Read(string @string)
        {
            return JsonConvert.DeserializeObject<Grammar>(@string);
        }

    }
}
