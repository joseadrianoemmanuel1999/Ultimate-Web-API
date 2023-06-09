using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    
        public record EmployeeDto(Guid Id, string Name, int Age, string Position);
       public record EmployeeForCreationDto
{
[Required(ErrorMessage = "Employee name is a required field.")]
[MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
public string? Name { get; init; }
[Required(ErrorMessage = "Age is a required field.")]
public int Age { get; init; }
[Required(ErrorMessage = "Position is a required field.")]
[MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
[Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
public string? Position { get; init; }
}
 public record EmployeeForUpdateDto
{
 [Required(ErrorMessage = "Employee name is a required field.")]
 [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
 public string? Name { get; init; }
 [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
 public int Age { get; init; }
 [Required(ErrorMessage = "Position is a required field.")]
 [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
 public string? Position { get; init; }
}
public abstract record EmployeeForManipulationDto
{
[Required(ErrorMessage = "Employee name is a required field.")]
[MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
public string? Name { get; init; }
[Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
public int Age { get; init; }
[Required(ErrorMessage = "Position is a required field.")]
[MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
public string? Position { get; init; }
public record EmployeeForCreationDto : EmployeeForManipulationDto;
public record EmployeeForUpdateDto : EmployeeForManipulationDto;

}


    
}
