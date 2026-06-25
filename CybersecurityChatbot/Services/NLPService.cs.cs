namespace CybersecurityChatbot.Services
{
    public class NLPService
    {
        // Detects user intent based on keyword matching
        public string DetectIntent(string input)
        {
            // Convert input to lowercase for easier matching
            input = input.ToLower();

            // Detect task-related commands
            if (input.Contains("add task") ||
                input.Contains("create task") ||
                input.Contains("new task") ||
                input.Contains("task"))
                return "TASK";

            // Detect reminder-related commands
            if (input.Contains("remind") ||
                input.Contains("reminder"))
                return "REMINDER";

            // Detect quiz/game/test related commands
            if (input.Contains("quiz") ||
                input.Contains("game") ||
                input.Contains("test"))
                return "QUIZ";

            // Detect activity/log/history related queries
            if (input.Contains("activity") ||
                input.Contains("log") ||
                input.Contains("history") ||
                input.Contains("what have you done"))
                return "ACTIVITY";

            // Default intent when nothing matches
            return "UNKNOWN";
        }
    }
}
