
using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class AddRoleDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Role { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Specialty { get; set; }
}
