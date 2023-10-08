using System.ComponentModel.DataAnnotations;

namespace MusicStore.Entities
{
    public class Genre : EntityBase
    {
        [StringLength(100)]  // Data Annotations tiene menos prioridad que el Fluent API
        public string Name { get; set; } = default!;
    }
}