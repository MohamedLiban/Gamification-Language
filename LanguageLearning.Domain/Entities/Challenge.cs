namespace LanguageLearning.Domain.Entities
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Description { get; set; }
        public int Difficulty { get; set; }  
    }
}
