using System;
using System.Collections.Generic;
using System.Text;

namespace Wellness.Application.DTOs
{
    public class DashboardDto
    {
        public decimal CurrentWeight { get; set; }

        public decimal GoalWeight { get; set; }

        public int TotalHabits { get; set; }

        public int CompletedHabits { get; set; }

        public int StreakDays { get; set; }
    }
}
