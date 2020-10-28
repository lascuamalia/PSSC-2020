using LanguageExt;
using LanguageExt.Common;
using Question.Domain.CreateQuestionsWorkflow;
using System;
using System.Collections.Generic;
using Question.Domain.CreateQuestionsWorkflow;
using Question.Domain.CreateQuestionsWorkflow.CreateQuestionResult;
using System.Net;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.Common;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var tgR = new Tags("t1", "t2", "t3");
            var textResult = Text.Create("textul pentru intrebare");
            textResult.Match(
                Succ: text =>
                {
                    Console.WriteLine("Textul este invalid");
                    return Unit.Default();
                },
                Fail: ex =>
                {
                    Console.WriteLine($"Textul este invalid. Motiv: {ex.Message}");
                    return Unit.Default();
                }

                );
            Console.ReadLine();
           
        }
       
    }
}
