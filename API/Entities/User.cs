namespace API.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }
    public string Gender {  get; set; }
    public string Introduction { get; set; }
    public string KnownAs { get; set; }
    public string LookingFor { get; set; }
    public string Intrests { get; set;}
    public string City {  get; set; }
    public string Country { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime LastActiveOn { get; set; } = DateTime.UtcNow;
    public List<Photo> Photos { get; set; } = new();
}
