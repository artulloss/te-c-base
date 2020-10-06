using System;
using System.Collections.Generic;
using System.IO;

namespace file_io_part1_exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = PromptForPath();
            List<Question> questions = ParseQuestions(path);
            PromptQuestions(questions, out int correctQuestions);
            string answerPlural = correctQuestions == 1 ? "answer" : "answers";
            Console.WriteLine($"You got {correctQuestions} {answerPlural} correct out of the {questions.Count} questions asked.");
        }

        private static string PromptForPath()
        {
            Console.WriteLine("Enter the fully qualified name of the file to read in for quiz questions");
            string path = Console.ReadLine() ?? "";
            if (!File.Exists(path))
            {
                return PromptForPath();
            }
            return path;
        }

        private static List<Question> ParseQuestions(string path)
        {
            List<Question> questions = new List<Question>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] lines = (sr.ReadLine() ?? "").Split("|");
                    string question = lines[0];
                    //Array.Copy(lines, 1, lines, 0, lines.Length - 2);
                    Answer[] answers = new Answer[lines.Length - 1];
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string answerString = lines[i];
                        bool isCorrect = answerString[answerString.Length - 1] == '*';
                        answers[i - 1] = new Answer(answerString, isCorrect);
                    }
                    questions.Add(new Question(question, answers));
                }
                return questions;
            }
        }
        
        private static void PromptQuestions(List<Question> questions, out int correctQuestions)
        {
            correctQuestions = 0;
            foreach (var question in questions)
            {
                bool validOption, outOfBounds;
                int selectedOption;
                Answer[] answers = null;
                do
                {
                    Console.WriteLine(question);
                    answers = question.GetAnswers();
                    for (int i = 0; i < answers.Length; i++)
                    {
                        string answerString = answers[i].ToString();
                        answerString = answerString[answerString.Length - 1] == '*'
                            ? answerString.Substring(0, answerString.Length - 1)
                            : answerString;
                        Console.WriteLine($"{i + 1}. {answerString}");
                    }
                    Console.Write("\nYour answer: ");
                    string selectedOptionString = Console.ReadLine();
                    validOption = int.TryParse(selectedOptionString, out selectedOption);
                    outOfBounds = selectedOption > answers.Length || selectedOption <= 0;
                    if (outOfBounds)
                    {
                        Console.WriteLine("Please select one of the options via their number.");
                    }
                } while (!validOption || outOfBounds);
                bool saidRightWrong = false;
                foreach (var correctAnswer in question.GetCorrectAnswers())
                {
                    if (answers[selectedOption - 1] == correctAnswer)
                    {
                        Console.WriteLine("RIGHT!\n");
                        saidRightWrong = true;
                        correctQuestions++;
                        break;
                    }
                }
                if (!saidRightWrong)
                {
                    Console.WriteLine("WRONG!\n");
                }
            }
        }
    }
}
