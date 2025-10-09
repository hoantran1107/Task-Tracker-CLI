using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Entites;

public class Task
{
    [Key]
    public int Id { get; set; }
    public string description { get; set; }
    [Required]
    public Status status { get; set; }
    public DateTime createAt { get; set; }
    public DateTime updatedAt { get; set; }
}