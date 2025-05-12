namespace ExamSystemApp
{
    public class ExamQuestion
    {
        public string QuestionText { get; set; }  // instead of Text
        public string[] Options { get; set; }     // instead of Opt or Answers
        public int CorrectAnswerIndex { get; set; } // instead of CorrectIndex
        public string Difficulty { get; set; }
        public string Course { get; set; }

        public ExamQuestion(string questionText, string[] options, int correctAnswerIndex, string difficulty, string course)
        {
            QuestionText = questionText;
            Options = options;
            CorrectAnswerIndex = correctAnswerIndex;
            Difficulty = difficulty;
            Course = course;
        }
    }
}
