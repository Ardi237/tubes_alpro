public class AdminList
{
    public bool Success { get; set; }          // success
    public string? Message { get; set; }       // message

    public long? AdminId { get; set; }         // admin_id (nullable kalau error)
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
}
