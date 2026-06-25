using System;

namespace CybersecurityChatbot.Database
{
    public class TaskModel
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ReminderDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsCompleted { get; set; }

        public string Status
        {
            get
            {
                return IsCompleted
                    ? "Completed"
                    : "Pending";
            }
        }
    }
}