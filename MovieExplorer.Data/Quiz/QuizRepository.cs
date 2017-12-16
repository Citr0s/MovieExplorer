using System.Collections.Generic;

namespace MovieExplorer.Data.Quiz
{
    public class QuizRepository
    {
        public QuizItemResponse GetAll()
        {
            var response = new QuizItemResponse
            {
                QuizQuestions = new List<QuizItem>
                {
                    new QuizItem
                    {
                        Question = "Who won his second Oscar in successive years for Forrest Gump?",
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer
                            {
                                Index = 1,
                                Answer = "Jennifer Lawrence"
                            },
                            new PossibleAnswer
                            {
                                Index = 1,
                                Answer = "Tom Hardy"
                            },
                            new PossibleAnswer
                            {
                                Index = 1,
                                Answer = "Tom Hanks"
                            },
                            new PossibleAnswer
                            {
                                Index = 1,
                                Answer = "Will Ferrell"
                            }
                        },
                        CorrectAnswer = "Tom Hanks"
                    },
                    new QuizItem
                    {
                        Question = "Who played Jack in Titanic?",
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer
                            {
                                Index = 2,
                                Answer = "Kate Winslet"
                            },
                            new PossibleAnswer
                            {
                                Index = 2,
                                Answer = "Brad Pitt"
                            },
                            new PossibleAnswer
                            {
                                Index = 2,
                                Answer = "Tom Hanks"
                            },
                            new PossibleAnswer
                            {
                                Index = 2,
                                Answer = "Leonardo DiCaprio"
                            }
                        },
                        CorrectAnswer = "Leonardo DiCaprio"
                    },
                    new QuizItem
                    {
                        Question = "What franchise is George Lucas must famous for?",
                        PossibleAnswers = new List<PossibleAnswer>
                        {
                            new PossibleAnswer
                            {
                                Index = 3,
                                Answer = "Star Wars"
                            },
                            new PossibleAnswer
                            {
                                Index = 3,
                                Answer = "Star Trek"
                            },
                            new PossibleAnswer
                            {
                                Index = 3,
                                Answer = "Harry Potter"
                            },
                            new PossibleAnswer
                            {
                                Index = 3,
                                Answer = "James Bond"
                            }
                        },
                        CorrectAnswer = "Star Wars"
                    }
                }
            };


            return response;
        }
    }
}