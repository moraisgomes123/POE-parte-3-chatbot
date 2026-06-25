namespace CybersecurityChatbot.Services
{
    public class NLPService
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            if (input.Contains("add task") ||
                input.Contains("create task") ||
                input.Contains("new task") ||
                input.Contains("task"))
                return "TASK";

            if (input.Contains("remind") ||
                input.Contains("reminder"))
                return "REMINDER";

            if (input.Contains("quiz") ||
                input.Contains("game") ||
                input.Contains("test"))
                return "QUIZ";

            if (input.Contains("activity") ||
                input.Contains("log") ||
                input.Contains("history") ||
                input.Contains("what have you done"))
                return "ACTIVITY";

            return "UNKNOWN";
        }
    }
}