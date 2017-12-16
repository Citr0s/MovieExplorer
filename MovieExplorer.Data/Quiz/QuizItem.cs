using System.Collections.Generic;

namespace MovieExplorer.Data.Quiz
{
    public class QuizItem
    {
        public QuizItem()
        {
            PossibleAnswers = new List<PossibleAnswer>();
        }

        public string Question { get; set; }
        public List<PossibleAnswer> PossibleAnswers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}