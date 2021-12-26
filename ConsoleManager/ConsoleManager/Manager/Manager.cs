﻿using ConsoleManager.Data.Models;
using ConsoleManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Manager
{
    internal class Manager : IManager
    {
        private QuestionLogic _questionLogic;
        private MenuLogic _menuLogic;
        private AnswerLogic _answerLogic;
        public Manager()
        {
            _answerLogic = new AnswerLogic();
            _menuLogic = new MenuLogic();
            _questionLogic = new QuestionLogic();
        }
        //Reader
        public virtual bool IsAnswerValid(Question question, Answer answer)
        {
            throw new NotImplementedException();
        }
        public virtual Answer ReadUserEntry(string userEntry, Question question, Answer answer)
        {
            throw new NotImplementedException();
        }
        //Writer
        public virtual void ShowMenu(Menu menu)
        {
            
        }
        public virtual void ShowMenus()
        {
            var menus = _menuLogic.GetMenus();
        }
        public virtual void WriteQuestion(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}