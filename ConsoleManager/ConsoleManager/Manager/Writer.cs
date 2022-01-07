using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Manager
{
    internal class Writer : Manager
    {
        //public override void WriteQuestion(Question question)
        //{
        //    int i = 0;
        //    switch (question.QuestionType)
        //    {
        //        case QuestionType.OuiNon:
        //            Console.WriteLine(question.Text);
        //            foreach (var possibleResponse in question.PossibleResponses)
        //            {
        //                i++;
        //                Console.WriteLine($"{i} : {possibleResponse}");
        //            }
        //            break;
        //        case QuestionType.ChoixMultiple:
        //            Console.WriteLine(question.Text);
        //            foreach (var possibleResponse in question.PossibleResponses)
        //            {
        //                i++;
        //                Console.WriteLine($"{i} : {possibleResponse}");
        //            }
        //            break;
        //        case QuestionType.ReponseLibre:
        //            Console.WriteLine(question.Text);
        //            break;
        //        default:
        //            break;
        //    }
        //}

    }
}
