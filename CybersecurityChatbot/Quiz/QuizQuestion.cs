using System.Collections.Generic;

namespace CybersecurityChatbot.Quiz
{
    public class QuizQuestion
    {
        // The question text shown to the user
        public string Question { get; set; }

        // Multiple-choice options (A, B, C, D)
        public List<string> Options { get; set; }

        // Correct answer (e.g., "A", "B", "C", "D")
        public string CorrectAnswer { get; set; }

        // Explanation shown after answering (why the answer is correct)
        public string Explanation { get; set; }
    }
}
