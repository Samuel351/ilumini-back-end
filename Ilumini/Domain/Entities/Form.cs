namespace Ilumini.Domain.Entities
{
    public class Form : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Question> Questions { get; set; } = [];

        public List<FormInstance> FormInstances { get; set; } = [];

        public Form() { }

        public Form(string name, string description, List<Question> questions) 
        { 
            Name = name;
            Description = description;
            Questions = questions;
        }
    }
}
