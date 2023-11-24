namespace WheaterForeCast.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedTime {  get; set; } = DateTime.UtcNow;
    }
}
