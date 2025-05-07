using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionCreationApp
{

    public class Question
    {
        public string Text { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }  // A, B, C, or D
        public string Category { get; set; }
        public string Difficulty { get; set; }

        public string Type { get; set; }

    }

}
