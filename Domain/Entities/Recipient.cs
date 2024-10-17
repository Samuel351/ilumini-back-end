namespace Domain.Entities
{
    public class Recipient : EntityBase
    {
        public string Email { get; set; }

        public List<FormInstance> FormInstances { get; set; } = [];

        public List<FormInstanceResponse> Responses { get; set; } = [];

        public Recipient() 
        { 
            Email = string.Empty;
        }
    }
}
