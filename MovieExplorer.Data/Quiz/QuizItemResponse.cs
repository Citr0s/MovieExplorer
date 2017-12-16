using System.Collections.Generic;

namespace MovieExplorer.Data.Quiz
{
    public class QuizItemResponse
    {
        public QuizItemResponse()
        {
            QuizQuestions = new List<QuizItem>();
        }

        public List<QuizItem> QuizQuestions { get; set; }
    }
}