using System.ComponentModel.DataAnnotations;

namespace MusicStore.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [StringLength(100)]  // Data Annotations tiene menos prioridad que el Fluent API
        public string Name { get; set; } = default!;
        public bool Status { get; set; }
        public Genre()
        {
            Status= true;
        }
    }
}