using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AbdulMuqsit.Fa11BCS008.Compiler.Lexer.Contracts;

namespace AbdulMuqsit.Fa11BCS008.Compiler.Lexer

{
    public partial class Lexer : ILexer
    {
        private char[] _input;

        public Lexer(string input) => _input = input.ToCharArray();

        //private members
        #region Private Members
        int _currentCharacterIndex = 0;
        int _currentLexemeBeginIndex = 0;
        char _currentCharacter;
        private Dictionary<string, Word> _words;
        #endregion

        //constructor 
        Lexer()
        {
            InitializePrivateMembers();

            ReserveKeywords();

            #region local function
            void ReserveKeywords()
            {
                ReserveKeyword(Words.IF);
                ReserveKeyword(Words.Else);
                ReserveKeyword(Words.While);
                ReserveKeyword(Words.Do);
                ReserveKeyword(Words.Break);
                ReserveKeyword(Words.True);
                ReserveKeyword(Words.False);
                ReserveKeyword(Types.Bool);
                ReserveKeyword(Types.Char);
                ReserveKeyword(Types.Bool);
                ReserveKeyword(Types.Float);

            }
            void ReserveKeyword(Word word) => _words.Add(word.Lexeme, word);
            void InitializePrivateMembers()
            {
                _currentCharacter = _input[_currentCharacterIndex];
                _words = new Dictionary<string, Word>();
            };
            #endregion

        }

        //the meat and bones of this class
        public Token GetNextToken()
        {

            while (_currentCharacterIndex < _input.Length)
            {
                SkipWhiteSpace();

                var token = AnalyzeCompositeTokens();
                if (token != null) return token;

                token = AnalyzeLiterals();
                if (token != null) return token;

                token = AnalyzeIdentifiers();
                if (token != null) return token;

                return AnalyzeOtherCharacters();

            }

            AdvanceCurrentLexeme();

            return new Token(Tag.AND);

            #region local functions

            //skips white space in the input, DAH!
            void SkipWhiteSpace()
            {
                while (_currentCharacter == '\t' || _currentCharacter == ' ')
                {
                    AdvanceCurrentCharacter();
                }


            };

            //go forward one character
            void AdvanceCurrentCharacter()
            {
                _currentCharacterIndex++;
                _currentCharacter = _input[_currentCharacterIndex];
            };

            //current lexeme is complete. move to one character after it
            void AdvanceCurrentLexeme()
            {
                AdvanceCurrentCharacter();
                _currentLexemeBeginIndex = _currentCharacterIndex;

            };

            //tells if the next character in the input is same as the argument
            bool IsNextCharacter(char character) => _input[_currentCharacterIndex + 1] == character;

            //analyze tokens e.g <=, == etc also their non composite alternatives e.g <, =
            Token AnalyzeCompositeTokens()
            {
                switch (_currentCharacter)
                {
                    case '&' when IsNextCharacter('&'):
                        return Words.And;
                    case '&':
                        return new Token(Tag.UnaryAnd);


                    case '|' when IsNextCharacter('|'):
                        return Words.Or;
                    case '|':
                        return new Token(Tag.UnaryOr);


                    case '=' when IsNextCharacter('='):
                        return Words.Equal;
                    case '=':
                        return new Token(Tag.Assignment);


                    case '<' when IsNextCharacter('='):
                        return Words.LessThanOrEqual;
                    case '<':
                        return new Token(Tag.LessThan);


                    case '>' when IsNextCharacter('='):

                        return Words.GreaterThanOrEqual;
                    case '>':
                        return new Token(Tag.GreaterThan);


                    case '!' when IsNextCharacter('='):
                        return Words.NotEqual;
                    case '!':
                        return new Token(Tag.UnaryNot);

                    default:
                        return null;
                }
            };

            //integer and float literals
            Token AnalyzeLiterals()
            {
                var literalValueStringBuilder = new StringBuilder();

                if (Char.IsDigit(_currentCharacter))
                {
                    while (Char.IsDigit(_currentCharacter))
                    {
                        literalValueStringBuilder.Append(_currentCharacter);
                        AdvanceCurrentCharacter();

                    }

                    if (_currentCharacter != '.')
                    {
                        return new Num(literalValueStringBuilder.ToString());
                    }
                    literalValueStringBuilder.Append(_currentCharacter);

                    while (Char.IsDigit(_currentCharacter))
                    {
                        literalValueStringBuilder.Append(_currentCharacter);
                        AdvanceCurrentCharacter();

                    }
                    return new Real(literalValueStringBuilder.ToString());

                }
                return null;
            }

            Token AnalyzeIdentifiers()
            {
                if (Char.IsLetter(_currentCharacter))
                {
                    var identifierNameStringBuilder = new StringBuilder();
                    while (Char.IsLetterOrDigit(_currentCharacter) || _currentCharacter == '_')
                    {
                        identifierNameStringBuilder.Append(_currentCharacter);
                        AdvanceCurrentCharacter();
                    }
                    var lexeme = identifierNameStringBuilder.ToString();
                    if (_words.ContainsKey(lexeme))
                    {
                        return _words[lexeme];
                    }
                    var word = new Word(lexeme, Tag.ID);
                    _words.Add(lexeme, word);
                    return word;
                }
                return null;
            }

            Token AnalyzeOtherCharacters()
            {
                return new Token(_currentCharacter);
            }
            #endregion
        }


    }

}



