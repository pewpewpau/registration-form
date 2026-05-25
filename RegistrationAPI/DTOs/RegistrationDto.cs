using System.ComponentModel.DataAnnotations;

namespace RegistrationAPI.DTOs;

public class RegistrationDto
{
    // Personal Info
    [Required(ErrorMessage = "First name is required.")]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }
    public DateOnly? DateOfBirth { get; set; }

    // Residential Address
    public string? ResCity     { get; set; }
    public string? ResStreet       { get; set; }
    public string? ResErf      { get; set; }
    public string? ResCountry    { get; set; }

    // Postal Address
    public string? PostAddress     { get; set; }
    public string? PostCity       { get; set; }
    public string? PostCountry    { get; set; }
}