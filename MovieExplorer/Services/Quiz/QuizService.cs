using System.Collections.Generic;
using MovieExplorer.Data.Quiz;

namespace MovieExplorer.Services.Quiz
{
    public class QuizService
    {
        private readonly QuizRepository _quizRepository;

        public QuizService(QuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public List<QuizItem> GetAll()
        {
            var response = new List<QuizItem>();
            var quizItemResponse = _quizRepository.GetAll();
            response.AddRange(quizItemResponse.QuizQuestions);
            return response;
        }
    }
}