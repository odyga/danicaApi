using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models;

public class CustomerModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    [MinLength(1, ErrorMessage = "Name must be at least 1 character long")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Surname is required")]
    [MaxLength(50, ErrorMessage = "Surname cannot exceed 50 characters")]
    [MinLength(1, ErrorMessage = "Surname must be at least 1 character long")]
    public required string Surname { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
    [MinLength(1, ErrorMessage = "Email must be at least 1 character long")]
    public required string Email { get; set; }
}