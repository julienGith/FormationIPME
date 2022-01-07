using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Manager
{
    internal class Reader : Manager
    {
        //public Answer ReadUserEntry(Question question)
        //{
        //    var userEntry = Console.ReadLine();
        //    while (String.IsNullOrEmpty(userEntry) || String.IsNullOrWhiteSpace(userEntry))
        //    {
        //        Console.WriteLine($"Saisie incorrecte : {userEntry}");
        //        Console.WriteLine("Veuillez ressaisir :");
        //        ReadUserEntry(question);
        //    }
        //    var result = uint.TryParse(userEntry, out uint choice);
        //    switch (question.QuestionType)
        //    {
        //        case QuestionType.OuiNon:

        //            while (!result || choice == 0 || choice > 2)
        //            {
        //                Console.WriteLine($"Saisie incorrecte : {userEntry}");
        //                ReadUserEntry(question);

        //            }
        //            break;
        //        case QuestionType.ChoixMultiple:
        //            while (!result || choice == 0 || choice > question.PossibleChoices)
        //            {
        //                Console.WriteLine($"Saisie incorrecte : {userEntry}");
        //                ReadUserEntry(question);
        //            }
        //            break;
        //        case QuestionType.ReponseLibre:
        //            choice = 0;
        //            break;
        //        default:
        //            break;
        //    }
        //    Answer answer = new Answer(userEntry, choice, question);
        //    return answer;
        //}

    }
}
