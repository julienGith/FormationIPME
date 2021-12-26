using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.Data.Models
{
    public class Menu
    {
        public Menu(string title, string greetingMessage,List<Question>? questions)
        {
            _title = title;
            _greetingMessage = greetingMessage;
            _questions= questions??new List<Question>();
        }
        private int _id { get; init; }
        public int Id { get { return _id; } }

        private string _greetingMessage;

        public string GreetingMessage
        {
            get { return _greetingMessage; }
            set { _greetingMessage = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private List<Question> _questions;

        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

    }
}
