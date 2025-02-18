﻿namespace LanguageLearning.Application.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> Options { get; set; }
    }
}
