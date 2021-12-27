using ConsoleManager.Data.Interfaces;
using ConsoleManager.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.Data.Functions
{
    public class QuestionFunctions : IQuestion
    {
        public Question CreateQuestion(Question question)
        {
            List<Question> quests = new List<Question>();
            if (!File.Exists(@"question.txt"))
            {
                using (FileStream fs = File.Create(@"question.txt"))
                {
                    quests.Add(question);

                    var jsonString = JsonConvert.SerializeObject(quests);
                    File.WriteAllText(@"question.txt", jsonString);
                    fs.Close();
                }
                return question;
            }

            return question;
        }

        public Question DeleteQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int questionId)
        {
            throw new NotImplementedException();
        }

        public Question UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
