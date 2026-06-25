using System.Collections.Generic;
using CybersecurityChatbot.Database;

namespace CybersecurityChatbot.Quiz
{
    public class QuizManager
    {
        // List of quiz questions
        private List<QuizQuestion> _questions;

        // Current question index
        private int _index;

        // User score
        private int _score;

        // Database helper for saving results and activity logs
        private DatabaseHelper _db = new DatabaseHelper();

        // Public read-only access to score
        public int Score => _score;

        // Constructor: initializes quiz
        public QuizManager()
        {
            _questions = BuildQuestions(); // Load questions
            _index = 0;                   // Start at first question
            _score = 0;                   // Reset score
        }

        // Returns current question
        public QuizQuestion GetCurrentQuestion()
        {
            if (_index >= _questions.Count)
                return null; // No more questions

            return _questions[_index];
        }

        // Checks if answer is correct and moves to next question
        public bool CheckAnswer(string answer)
        {
            bool correct = _questions[_index].CorrectAnswer == answer;

            if (correct)
                _score++; // Increase score if correct

            _index++; // Move to next question

            return correct;
        }

        // Checks if quiz is finished
        public bool IsFinished()
        {
            return _index >= _questions.Count;
        }

        // Restarts quiz
        public void Restart()
        {
            _index = 0;
            _score = 0;
        }

        // Calculates final result and saves to database
        public string GetFinalResult()
        {
            // Save score in database
            _db.SaveQuizResult(_score, _questions.Count);

            // Log activity
            _db.AddActivity(
                "QUIZ",
                "Quiz completed: " + _score + "/" + _questions.Count);

            // Return performance message
            if (_score >= 12)
                return "Excellent! You are a cybersecurity pro!";

            if (_score >= 8)
                return "Good job! Keep improving.";

            return "Keep learning cybersecurity basics.";
        }

        // Builds all quiz questions
        private List<QuizQuestion> BuildQuestions()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new List<string>
                    {
                        "A banking app",
                        "Fake messages to steal data",
                        "Firewall software",
                        "Password manager"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Phishing tricks users into giving personal data."
                },

                new QuizQuestion
                {
                    Question = "What is 2FA?",
                    Options = new List<string>
                    {
                        "Extra login security",
                        "Antivirus tool",
                        "Email filter",
                        "Browser plugin"
                    },
                    CorrectAnswer = "A",
                    Explanation = "2FA adds an extra layer of security."
                },

                new QuizQuestion
                {
                    Question = "What is malware?",
                    Options = new List<string>
                    {
                        "Useful software",
                        "Harmful software",
                        "Cloud storage",
                        "Search engine"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Malware is software designed to harm or steal data."
                },

                new QuizQuestion
                {
                    Question = "What is a firewall?",
                    Options = new List<string>
                    {
                        "Hardware store",
                        "Network protection system",
                        "Video game",
                        "Email service"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Firewalls block unauthorized access."
                },

                new QuizQuestion
                {
                    Question = "What is a strong password?",
                    Options = new List<string>
                    {
                        "123456",
                        "Your name",
                        "Mix of letters, numbers, symbols",
                        "Your birthday"
                    },
                    CorrectAnswer = "C",
                    Explanation = "Strong passwords use complexity to stay secure."
                },

                new QuizQuestion
                {
                    Question = "What is social engineering?",
                    Options = new List<string>
                    {
                        "Engineering software",
                        "Tricking people to reveal information",
                        "Coding websites",
                        "Building networks"
                    },
                    CorrectAnswer = "B",
                    Explanation = "It manipulates people instead of systems."
                },

                new QuizQuestion
                {
                    Question = "What is ransomware?",
                    Options = new List<string>
                    {
                        "Free software",
                        "Malware that locks files",
                        "Antivirus tool",
                        "VPN service"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Ransomware encrypts files and demands payment."
                },

                new QuizQuestion
                {
                    Question = "What is a VPN?",
                    Options = new List<string>
                    {
                        "Virtual Private Network",
                        "Virus Protection Node",
                        "Video Player Network",
                        "Verified Password Name"
                    },
                    CorrectAnswer = "A",
                    Explanation = "VPN encrypts internet traffic."
                },

                new QuizQuestion
                {
                    Question = "What is spyware?",
                    Options = new List<string>
                    {
                        "Useful tool",
                        "Software that spies on users",
                        "Firewall system",
                        "Browser extension"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Spyware secretly collects user data."
                },

                new QuizQuestion
                {
                    Question = "What is encryption?",
                    Options = new List<string>
                    {
                        "Hiding data using codes",
                        "Deleting files",
                        "Sending emails",
                        "Creating apps"
                    },
                    CorrectAnswer = "A",
                    Explanation = "Encryption protects data by encoding it."
                },

                new QuizQuestion
                {
                    Question = "What is a phishing email sign?",
                    Options = new List<string>
                    {
                        "Official domain",
                        "Urgent suspicious request",
                        "Personal email",
                        "Verified sender"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Phishing emails create urgency or fear."
                },

                new QuizQuestion
                {
                    Question = "What is a secure website?",
                    Options = new List<string>
                    {
                        "HTTP",
                        "HTTPS",
                        "FTP",
                        "SMTP"
                    },
                    CorrectAnswer = "B",
                    Explanation = "HTTPS encrypts communication."
                },

                new QuizQuestion
                {
                    Question = "What does antivirus do?",
                    Options = new List<string>
                    {
                        "Creates websites",
                        "Removes malware",
                        "Sends emails",
                        "Speeds internet"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Antivirus detects and removes threats."
                },

                new QuizQuestion
                {
                    Question = "What is a data breach?",
                    Options = new List<string>
                    {
                        "Backup system",
                        "Unauthorized data access",
                        "Firewall update",
                        "Login system"
                    },
                    CorrectAnswer = "B",
                    Explanation = "A data breach exposes sensitive information."
                }
            };
        }
    }
}
