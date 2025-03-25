using System.ComponentModel.DataAnnotations;

namespace LobraryApp.Data.Entities;

public abstract class BaseEntity<TId>
{
    [Key]
    public TId Id { get; set; } = default!;
}