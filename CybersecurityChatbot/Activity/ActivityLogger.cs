using System;
using System.Collections.Generic;
using System.Linq;
using CybersecurityChatbot.Database;

namespace CybersecurityChatbot.Activity
{
    public class ActivityLogger
    {
        private List<ActivityItem> _activities =
            new List<ActivityItem>();

        private DatabaseHelper _db =
            new DatabaseHelper();

        // =========================
        // ADD ACTIVITY
        // =========================
        public void AddActivity(string type, string description)
        {
            ActivityItem item = new ActivityItem();

            item.TimeStamp = DateTime.Now;
            item.Category = type;
            item.Description = description;

            _activities.Add(item);

            _db.AddActivity(type, description);
        }

        // =========================
        // GET RECENT (used by UI)
        // =========================
        public List<ActivityItem> GetRecentActivities(int count)
        {
            return _activities
                .OrderByDescending(x => x.TimeStamp)
                .Take(count)
                .ToList();
        }

        // =========================
        // FIX: ALIAS FOR YOUR UI
        // =========================
        public List<ActivityItem> GetAllActivities()
        {
            return _activities
                .OrderByDescending(x => x.TimeStamp)
                .ToList();
        }
    }
}