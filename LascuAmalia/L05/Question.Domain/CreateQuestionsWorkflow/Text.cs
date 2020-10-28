using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Question.Domain.CreateQuestionsWorkflow
{
   public  class Text
    {
        public string Textt { get; private set; }
        private Text(string text)
        {
            Textt = text;
        }

        public static Result<Text> Create(string text)
        {
            if(IsTextValid(text))
            {
                return new Text(text);
            }
            else
            {
                return new Result<Text>(new InvalidTextException(text));
            }
        }
        
        private static bool IsTextValid(string text)
        {
            if(text.Length<=1000)
            {
                return true;
            }
            return false;
        }
        


    }

    [Serializable]
    internal class InvalidTextException : Exception
    {
        public InvalidTextException()
        {
        }

        public InvalidTextException(string text) : base($"Ati depasit numarul de caractere,aveti voie maxim 1000 de caractere")
        {
        }

       
    }
}
