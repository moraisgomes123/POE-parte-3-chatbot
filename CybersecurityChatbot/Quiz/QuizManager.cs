using System.Collections.Generic;
using CybersecurityChatbot.Database;

namespace CybersecurityChatbot.Quiz
{
    public class QuizManager
    {
        private List<QuizQuestion> _questions;
        private int _index;
        private int _score;

        private DatabaseHelper _db = new DatabaseHelper();

        public int Score => _score;

        public QuizManager()
        {
            _questions = BuildQuestions();
            _index = 0;
            _score = 0;
        }

        public QuizQuestion GetCurrentQuestion()
        {
            if (_index >= _questions.Count)
                return null;

            return _questions[_index];
        }

        public bool CheckAnswer(string answer)
        {
            bool correct =
                _questions[_index].CorrectAnswer == answer;

            if (correct)
                _score++;

            _index++;

            return correct;
        }

        public bool IsFinished()
        {
            return _index >= _questions.Count;
        }

        public void Restart()
        {
            _index = 0;
            _score = 0;
        }

        public string GetFinalResult()
        {
            _db.SaveQuizResult(
                _score,
                _questions.Count);

            _db.AddActivity(
                "QUIZ",
                "Quiz completed: " +
                _score + "/" +
                _questions.Count);

            if (_score >= 12)
                return "Excellent! You are a cybersecurity pro!";

            if (_score >= 8)
                return "Good job! Keep improving.";

            return "Keep learning cybersecurity basics.";
        }

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
                    Explanation = "Malware is designed to damage or steal data."
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
                    Explanation = "Strong passwords are complex and hard to guess."
                },

                new QuizQuestion
                {
                    Question = "What is social engineering?",
                    Options = new List<string>
                    {
                        "Engineering software",
                        "Tricking people to reveal info",
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
                    Explanation = "Spyware collects user data secretly."
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