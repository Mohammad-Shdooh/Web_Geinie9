using MessagePack;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_Geinie9.Models;

public partial class User
{


    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage ="please Enter valid name")]
    public string? FullName { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$",
                            ErrorMessage = "Please enter a valid email address")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Pass is required.")]
    [MinLength(6, ErrorMessage = "Min Length should be 6")]
    public string? Pass { get; set; }
    [Required(ErrorMessage = "ConfirmPassword is required.")]
    [MinLength(6,ErrorMessage ="Min Length should be 6")]
    [Compare("Pass", ErrorMessage = "Password dose not match.")]

    public string? ConfirmPassword { get; set; }
}
