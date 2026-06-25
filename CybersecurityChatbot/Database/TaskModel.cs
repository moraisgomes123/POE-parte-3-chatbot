using System;

namespace CybersecurityChatbot.Database
{
    public class TaskModel
    {
        // Unique ID for each task
        public int TaskId { get; set; }

        // Title of the task
        public string Title { get; set; }

        // Detailed description of the task
        public string Description { get; set; }

        // Optional reminder date for the task
        public DateTime? ReminderDate { get; set; }

        // Date when the task was created
        public DateTime CreatedDate { get; set; }

        // Indicates whether the task is completed or not
        public bool IsCompleted { get; set; }

        // Read-only property that returns task status based on IsCompleted
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
