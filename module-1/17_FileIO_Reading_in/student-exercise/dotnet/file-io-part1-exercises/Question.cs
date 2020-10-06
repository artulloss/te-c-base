using System.Collections.Generic;
using System.Linq;

namespace file_io_part1_exercises
{
    public class Question
    {
        private readonly Answer[] _answers;
        private readonly string _questionString;
        private List<Answer> _correctAnswers = new List<Answer>();

        public Question(string questionString, Answer[] answers)
        {
            _questionString = questionString;
            _answers = answers;
            
            foreach (Answer correctAnswer in answers.Where(a => a.IsCorrect))
            {
                _correctAnswers.Add(correctAnswer);
            }
        }

        public Answer[] GetCorrectAnswers()
        {
            return _correctAnswers.ToArray();
        }
        
        public Answer[] GetAnswers()
        {
            return _answers;
        }

        public override string ToString()
        {
            return _questionString;
        }
    }
}