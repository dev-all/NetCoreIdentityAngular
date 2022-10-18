namespace allshop.api.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }        
        public Boolean Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
