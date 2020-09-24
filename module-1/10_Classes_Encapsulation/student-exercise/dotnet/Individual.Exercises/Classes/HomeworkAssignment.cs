namespace Individual.Exercises.Classes
{
    public class HomeworkAssignment
    {
        public int EarnedMarks { get; set; }
        public int PossibleMarks { get; private set; }
        public string SubmitterName { get; private set; }

        public HomeworkAssignment(int possibleMarks, string submitterName)
        {
            PossibleMarks = possibleMarks;
            SubmitterName = submitterName;
        }

        public string LetterGrade
        {
            get
            {
                float scorePercent = (float) EarnedMarks / PossibleMarks;
                if (scorePercent > 0.9)
                    return "A";
                if (scorePercent > 0.8)
                    return "B";
                if (scorePercent > 0.7)
                    return "C";
                if (scorePercent > 0.6)
                    return "D";
                return "F";
            }
        }
    }
}
