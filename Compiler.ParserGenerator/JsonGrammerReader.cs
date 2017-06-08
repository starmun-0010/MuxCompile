using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Compiler.Common;
using Newtonsoft.Json;

namespace Compiler.ParserGenerator
{
    public class JsonGrammerReader : IGrammarReader
    {
        public IGrammar Read(string @string)
        {
            return JsonConvert.DeserializeObject<Grammar>(@string);
        }

    }
}
