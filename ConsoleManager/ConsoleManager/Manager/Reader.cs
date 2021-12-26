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
        public override bool IsAnswerValid(Question question, Answer answer)
        {
            return true;
        }
    }
}
