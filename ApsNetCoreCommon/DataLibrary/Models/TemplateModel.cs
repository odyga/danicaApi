using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models;

public class TemplateModel
{
    public int Id { get; set; }

    [MaxLength(50, ErrorMessage = "Template name cannot exceed 50 characters")]
    [Display(Name = "Template Name")]
    public required string Name { get; set; }

    [MaxLength(50, ErrorMessage = "Template subject cannot exceed 50 characters")]
    public required string Subject { get; set; }

    [MaxLength(666, ErrorMessage = "Template body cannot exceed 666 characters")]
    public required string Body { get; set; }
}
