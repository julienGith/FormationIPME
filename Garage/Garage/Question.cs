using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Garage.Const;

namespace Garage
{
    internal class Question
    {
        private string _text;
        private uint _answer;
        private uint _possibleChoices;
        private ExpectedAnswerType _expectedAnswerType;
        public Question(string text, uint possibleChoices, ExpectedAnswerType ExpectedAnswerType)
        {
            _text = text;
            _possibleChoices = possibleChoices;
            _expectedAnswerType = ExpectedAnswerType;
        }
        public ExpectedAnswerType ExpectedAnswerType
        {
            get { return _expectedAnswerType; }
            set { _expectedAnswerType = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public uint Answer
        {
            get { return _answer; }
            set { _answer = value; }
        }
        public uint PossibleChoices
        {
            get { return _possibleChoices; }
            set { _possibleChoices = value; }
        }



    }
}
