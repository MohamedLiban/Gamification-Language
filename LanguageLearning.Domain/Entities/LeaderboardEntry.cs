﻿namespace LanguageLearning.Domain.Entities
{
    public class LeaderboardEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public User User { get; set; }
    }
}
