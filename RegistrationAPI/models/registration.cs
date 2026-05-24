using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationAPI.Models;

[Table("registrations")]
public class Registration
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Personal Info
    [Required]
    [Column("first_name")]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Column("last_name")]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [Column("email")]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [Column("phone")]
    [MaxLength(20)]
    public string? Phone { get; set; }

    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    // Residential Address
    [Column("res_city")]    public string? ResCity { get; set; }
    [Column("res_street")]  public string? ResStreet { get; set; }
    [Column("res_erf")]   public string? ResErf { get; set; }
    [Column("res_country")] public string? ResCountry { get; set; }

    // Postal Address
    [Column("post_address")]  public string? PostAddress { get; set; }
    [Column("post_city")]    public string? PostCity { get; set; }
    [Column("post_country")] public string? PostCountry { get; set; }
}