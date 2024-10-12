namespace Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Soft delete in Database
        /// </summary>
        public bool Deleted { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public bool Status { get; set; } = true;
    }
}
