using System;
using System.Collections.Generic;
using System.Linq;
using CybersecurityChatbot.Database;

namespace CybersecurityChatbot.Services
{
    public class ReminderService
    {
        public List<TaskModel> GetDueReminders(
            List<TaskModel> tasks)
        {
            return tasks
                .Where(t =>
                    !t.IsCompleted &&
                    t.ReminderDate.HasValue &&
                    t.ReminderDate.Value.Date <= DateTime.Today)
                .ToList();
        }

        public string GenerateReminderMessage(
            TaskModel task)
        {
            return
                $"Reminder: {task.Title}\n\n" +
                $"Description: {task.Description}";
        }
    }
}