using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Data;
using RegistrationAPI.DTOs;
using RegistrationAPI.Models;

namespace RegistrationAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly AppDbContext _db;

    public RegistrationController(AppDbContext db) => _db = db;

    // POST api/registration
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RegistrationDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse<object>.Fail(
                string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage))));

        bool emailExists = await _db.Registrations
            .AnyAsync(r => r.Email == dto.Email);

        if (emailExists)
            return Conflict(ApiResponse<object>.Fail("Email is already registered."));

        var registration = new Registration
        {
            FirstName      = dto.FirstName,
            LastName       = dto.LastName,
            Email          = dto.Email,
            Phone          = dto.Phone,
            DateOfBirth    = dto.DateOfBirth,
            ResCity        = dto.ResCity,
            ResStreet      = dto.ResStreet,
            ResErf         = dto.ResErf,
            ResCountry     = dto.ResCountry,
            PostAddress    = dto.PostAddress,
            PostCity       = dto.PostCity,
            PostCountry    = dto.PostCountry,
        };

        _db.Registrations.Add(registration);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById),
            new { id = registration.Id },
            ApiResponse<Registration>.Ok(registration, "Registration successful."));
    }

    // GET api/registration
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _db.Registrations
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();

        return Ok(ApiResponse<List<Registration>>.Ok(list));
    }

    // GET api/registration/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var reg = await _db.Registrations.FindAsync(id);
        if (reg is null)
            return NotFound(ApiResponse<object>.Fail($"Registration #{id} not found."));

        return Ok(ApiResponse<Registration>.Ok(reg));
    }

    // PUT api/registration/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] RegistrationDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ApiResponse<object>.Fail("Invalid data."));

        var reg = await _db.Registrations.FindAsync(id);
        if (reg is null)
            return NotFound(ApiResponse<object>.Fail($"Registration #{id} not found."));

        reg.FirstName      = dto.FirstName;
        reg.LastName       = dto.LastName;
        reg.Email          = dto.Email;
        reg.Phone          = dto.Phone;
        reg.DateOfBirth    = dto.DateOfBirth;
        reg.ResCity        = dto.ResCity;
        reg.ResStreet      = dto.ResStreet;
        reg.ResErf         = dto.ResErf;
        reg.ResCountry     = dto.ResCountry;
        reg.PostAddress    = dto.PostAddress;
        reg.PostCity       = dto.PostCity;
        reg.PostCountry    = dto.PostCountry;

        await _db.SaveChangesAsync();
        return Ok(ApiResponse<Registration>.Ok(reg, "Updated successfully."));
    }

    // DELETE api/registration/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var reg = await _db.Registrations.FindAsync(id);
        if (reg is null)
            return NotFound(ApiResponse<object>.Fail($"Registration #{id} not found."));

        _db.Registrations.Remove(reg);
        await _db.SaveChangesAsync();
        return Ok(ApiResponse<object>.Fail($"Registration #{id} deleted."));
    }
}