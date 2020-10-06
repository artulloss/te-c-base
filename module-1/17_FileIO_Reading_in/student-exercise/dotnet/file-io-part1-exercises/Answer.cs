namespace file_io_part1_exercises
{
    public class Answer
    {
        public string AnswerString { get; }
        public bool IsCorrect { get; }
        
        public Answer(string answerString, bool isCorrect = false)
        {
            AnswerString = answerString;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return AnswerString;
        }
    }
}