using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.Data.Interfaces
{
    public interface IQuestion
    {
        Question GetQuestionById(int questionId);
        Question CreateQuestion(Question question);
        Question UpdateQuestion(Question question);
        Question DeleteQuestion(Question question);
    }
}
