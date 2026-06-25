using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

using CybersecurityChatbot.Chatbot;
using CybersecurityChatbot.Services;
using CybersecurityChatbot.Database;
using CybersecurityChatbot.Activity;
using CybersecurityChatbot.Quiz;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        // ==========================
        // PART 2 CHATBOT
        // ==========================

        private readonly ChatbotEngine _chatbot;
        private readonly VoiceGreeting _voiceGreeting =
            new VoiceGreeting();

        // ==========================
        // PART 3 SERVICES
        // ==========================

        private readonly DatabaseHelper _database =
            new DatabaseHelper();

        private readonly ActivityLogger _activityLogger =
            new ActivityLogger();

        private readonly QuizManager _quizManager =
            new QuizManager();

        private readonly NLPService _nlpService =
            new NLPService();

        private readonly ReminderService _reminderService =
            new ReminderService();

        // Show More support

        private int _activityDisplayCount = 5;

        // ==========================
        // CONSTRUCTOR
        // ==========================

        public MainWindow()
        {
            InitializeComponent();

            // ASCII Banner

            AsciiBanner.Text = @"
╔══════════════════════════════════════════════════════════════╗
║        ░█████╗░██╗░░░██╗██████╗░███████╗██████╗░             ║
║        ██╔══██╗╚██╗░██╔╝██╔══██╗██╔════╝██╔══██╗             ║
║        ██║░░╚═╝░╚████╔╝░██████╦╝█████╗░░██████╔╝             ║
║        ██║░░██╗░░╚██╔╝░░██╔══██╗██╔══╝░░██╔══██╗             ║
║        ╚█████╔╝░░░██║░░░██████╦╝███████╗██║░░██║             ║
║        ░╚════╝░░░░╚═╝░░░╚═════╝░╚══════╝╚═╝░░╝               ║
║                 CYBERSECURITY AWARENESS BOT                 ║
║                     Stay Safe Online!                       ║
╚══════════════════════════════════════════════════════════════╝";

            // ==========================
            // LOAD CHATBOT
            // ==========================

            var loader =
                new JsonResponseLoader(
                    "Data/responses.json");

            var responses =
                loader.LoadResponses();

            var responseService =
                new ResponseService(responses);

            _chatbot =
                new ChatbotEngine(responseService);

            // Welcome Message

            AppendMessage(
                "Chatbot",
                "Hello! What is your name?",
                Colors.Cyan);

            // ==========================
            // LOAD TASKS
            // ==========================

            LoadTasks();

            // ==========================
            // LOAD ACTIVITY
            // ==========================

            RefreshActivityLog();

            // ==========================
            // CHECK REMINDERS
            // ==========================

            CheckDueReminders();

            // ==========================
            // WINDOW EVENTS
            // ==========================

            Loaded += MainWindow_Loaded;
        }

        // ==========================
        // WINDOW LOADED
        // ==========================

        private async void MainWindow_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            await _voiceGreeting.PlayGreetingAsync();
        }

        // ==========================
        // LOAD TASKS FROM DATABASE
        // ==========================

        private void LoadTasks()
        {
            try
            {
                TasksDataGrid.ItemsSource =
                    _database.GetTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load tasks.\n\n" +
                    ex.Message);
            }
        }

        // ==========================
        // CHECK REMINDERS
        // ==========================

        private void CheckDueReminders()
        {
            try
            {
                List<TaskModel> tasks =
                    _database.GetTasks();

                var reminders =
                    _reminderService
                    .GetDueReminders(tasks);

                foreach (var task in reminders)
                {
                    MessageBox.Show(
                        _reminderService
                        .GenerateReminderMessage(task),
                        "Cybersecurity Reminder");

                    _activityLogger.AddActivity(
                        "REMINDER",
                        "Reminder shown: " +
                        task.Title);
                }
            }
            catch
            {
            }
        }

        // ==========================
        // REFRESH ACTIVITY LOG
        // ==========================

        private void RefreshActivityLog()
        {
            ActivityListBox.Items.Clear();

            var logs =
                _activityLogger
                .GetRecentActivities(
                    _activityDisplayCount);

            foreach (var item in logs)
            {
                ActivityListBox.Items.Add(
                    $"[{item.TimeStamp:G}] " +
                    $"{item.Category} - " +
                    $"{item.Description}");
            }
        }

        // ==========================
        // CHAT MESSAGE FORMATTER
        // ==========================

        private void AppendMessage(
            string sender,
            string message,
            Color color)
        {
            Paragraph paragraph =
                new Paragraph();

            paragraph.Inlines.Add(
                new Run(sender + ": ")
                {
                    Foreground =
                        new SolidColorBrush(color),

                    FontWeight =
                        FontWeights.Bold
                });

            paragraph.Inlines.Add(
                new Run(message)
                {
                    Foreground =
                        new SolidColorBrush(
                            Colors.White)
                });

            ChatDisplay.Document
                .Blocks
                .Add(paragraph);

            ChatDisplay.ScrollToEnd();
        }
        // ==========================
        // CHATBOT SEND BUTTON
        // ==========================

        private void SendButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            string input =
                UserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
                return;

            string displayName =
                string.IsNullOrWhiteSpace(
                    _chatbot.UserName)
                ? "You"
                : _chatbot.UserName;

            AppendMessage(
                displayName,
                input,
                Colors.LightGreen);

            // ==========================
            // NLP DETECTION
            // ==========================

            string intent =
                _nlpService.DetectIntent(input);

            HandleNlpAction(intent, input);

            // ==========================
            // EXISTING CHATBOT
            // ==========================

            string response =
                _chatbot.ProcessMessage(input);

            AppendMessage(
                "Chatbot",
                response,
                Colors.Cyan);

            UserInput.Clear();
        }

        // ==========================
        // NLP ACTIONS
        // ==========================

        private void HandleNlpAction(
            string intent,
            string input)
        {
            switch (intent)
            {
                case "ADD_TASK":

                    _activityLogger.AddActivity(
                        "NLP",
                        "Detected task request");

                    RefreshActivityLog();

                    AppendMessage(
                        "Chatbot",
                        "I detected that you want to create a cybersecurity task. Open the Task Assistant tab to save it.",
                        Colors.Orange);

                    break;

                case "REMINDER":

                    _activityLogger.AddActivity(
                        "NLP",
                        "Detected reminder request");

                    RefreshActivityLog();

                    AppendMessage(
                        "Chatbot",
                        "It sounds like you want a reminder. Create a task and choose a reminder date.",
                        Colors.Orange);

                    break;

                case "QUIZ":

                    _activityLogger.AddActivity(
                        "QUIZ",
                        "Quiz requested via chatbot");

                    RefreshActivityLog();

                    AppendMessage(
                        "Chatbot",
                        "Open the Cybersecurity Quiz tab and click Start Quiz.",
                        Colors.Orange);

                    break;

                case "ACTIVITY":

                    ShowRecentActivities();

                    break;
            }
        }

        // ==========================
        // SHOW ACTIVITY IN CHAT
        // ==========================

        private void ShowRecentActivities()
        {
            var logs =
                _activityLogger
                .GetRecentActivities(5);

            if (logs.Count == 0)
            {
                AppendMessage(
                    "Chatbot",
                    "No activity has been recorded yet.",
                    Colors.Cyan);

                return;
            }

            AppendMessage(
                "Chatbot",
                "Here are your recent activities:",
                Colors.Cyan);

            foreach (var item in logs)
            {
                AppendMessage(
                    "Activity",
                    $"[{item.TimeStamp:G}] {item.Category} - {item.Description}",
                    Colors.Yellow);
            }
        }

        // ==========================
        // ADD TASK
        // ==========================

        private void AddTaskButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(
                    TaskTitleTextBox.Text))
                {
                    MessageBox.Show(
                        "Task title is required.");

                    return;
                }

                TaskModel task =
                    new TaskModel
                    {
                        Title =
                            TaskTitleTextBox.Text,

                        Description =
                            TaskDescriptionTextBox.Text,

                        ReminderDate =
                            ReminderDatePicker.SelectedDate
                    };

                bool success =
                    _database.AddTask(task);

                if (success)
                {
                    MessageBox.Show(
                        "Task added successfully.");

                    _activityLogger.AddActivity(
                        "TASK",
                        "Task added: " +
                        task.Title);

                    LoadTasks();
                    RefreshActivityLog();

                    TaskTitleTextBox.Clear();
                    TaskDescriptionTextBox.Clear();
                    ReminderDatePicker.SelectedDate = null;
                }
                else
                {
                    MessageBox.Show(
                        "Failed to add task.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // ==========================
        // REFRESH TASKS
        // ==========================

        private void RefreshTaskButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            LoadTasks();

            _activityLogger.AddActivity(
                "TASK",
                "Task list refreshed");

            RefreshActivityLog();
        }

        // ==========================
        // MARK COMPLETED
        // ==========================

        private void CompleteTaskButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                TaskModel selectedTask =
                    TasksDataGrid.SelectedItem
                   as TaskModel;

                if (selectedTask == null)
                {
                    MessageBox.Show(
                        "Select a task first.");

                    return;
                }

                bool success =
                    _database.MarkCompleted(
                        selectedTask.TaskId);

                if (success)
                {
                    _activityLogger.AddActivity(
                        "TASK",
                        "Task completed: " +
                        selectedTask.Title);

                    LoadTasks();
                    RefreshActivityLog();

                    MessageBox.Show(
                        "Task marked completed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // ==========================
        // DELETE TASK
        // ==========================

        private void DeleteTaskButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                TaskModel selectedTask =
                    TasksDataGrid.SelectedItem
                    as TaskModel;

                if (selectedTask == null)
                {
                    MessageBox.Show(
                        "Select a task first.");

                    return;
                }

                bool success =
                    _database.DeleteTask(
                        selectedTask.TaskId);

                if (success)
                {
                    _activityLogger.AddActivity(
                        "TASK",
                        "Task deleted: " +
                        selectedTask.Title);

                    LoadTasks();
                    RefreshActivityLog();

                    MessageBox.Show(
                        "Task deleted.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
        // ==========================
        // START QUIZ
        // ==========================

        private void StartQuizButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                _quizManager.Restart();

                _activityLogger.AddActivity(
                    "QUIZ",
                    "Quiz started");

                RefreshActivityLog();

                LoadCurrentQuestion();

                QuizResultTextBlock.Text =
                    "Quiz started. Good luck!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ==========================
        // LOAD CURRENT QUESTION
        // ==========================

        private void LoadCurrentQuestion()
        {
            QuizQuestion question =
                _quizManager.GetCurrentQuestion();

            if (question == null)
            {
                ShowQuizResults();
                return;
            }

            QuestionTextBlock.Text =
                question.Question;

            OptionA.Foreground = Brushes.White;
            OptionB.Foreground = Brushes.White;
            OptionC.Foreground = Brushes.White;
            OptionD.Foreground = Brushes.White;

            OptionA.Content = "A) " + question.Options[0];
            OptionB.Content = "B) " + question.Options[1];
            OptionC.Content = "C) " + question.Options[2];
            OptionD.Content = "D) " + question.Options[3];

            OptionA.IsChecked = false;
            OptionB.IsChecked = false;
            OptionC.IsChecked = false;
            OptionD.IsChecked = false;
        }

        // ==========================
        // SUBMIT ANSWER
        // ==========================

        private void SubmitAnswerButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                string answer = "";

                if (OptionA.IsChecked == true) answer = "A";
                else if (OptionB.IsChecked == true) answer = "B";
                else if (OptionC.IsChecked == true) answer = "C";
                else if (OptionD.IsChecked == true) answer = "D";

                if (string.IsNullOrWhiteSpace(answer))
                {
                    MessageBox.Show(
                        "Please select an answer.");

                    return;
                }

                QuizQuestion currentQuestion =
                    _quizManager.GetCurrentQuestion();

                bool correct =
                    _quizManager.CheckAnswer(answer);

                if (correct)
                {
                    QuizResultTextBlock.Text =
                        "✅ Correct!\n\n" +
                        currentQuestion.Explanation;
                }
                else
                {
                    QuizResultTextBlock.Text =
                        "❌ Incorrect.\n\n" +
                        currentQuestion.Explanation;
                }

                if (_quizManager.IsFinished())
                {
                    ShowQuizResults();
                }
                else
                {
                    LoadCurrentQuestion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ==========================
        // SHOW FINAL QUIZ RESULT
        // ==========================

        private void ShowQuizResults()
        {
            string result =
                _quizManager.GetFinalResult();

            QuizResultTextBlock.Text =
                $"Final Score: {_quizManager.Score}/10\n\n" +
                result;

            _activityLogger.AddActivity(
                "QUIZ",
                $"Quiz completed. Score {_quizManager.Score}/10");

            RefreshActivityLog();

            AppendMessage(
                "Chatbot",
                $"Quiz completed! {_quizManager.Score}/10. {result}",
                Colors.Cyan);
        }

        // ==========================
        // SHOW MORE ACTIVITY
        // ==========================

        private void ShowMoreButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            _activityDisplayCount += 5;

            var logs =
                _activityLogger.GetAllActivities();

            ActivityListBox.Items.Clear();

            foreach (var item in logs)
            {
                ActivityListBox.Items.Add(
                    $"[{item.TimeStamp:G}] " +
                    $"{item.Category} - " +
                    $"{item.Description}");
            }
        }
    }
} 