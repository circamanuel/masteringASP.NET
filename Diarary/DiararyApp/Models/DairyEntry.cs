using System.ComponentModel.DataAnnotations;

namespace DiararyApp.Models
{
    public class DairyEntry
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public  DateTime Create { get; set;} = DateTime.Now;
    }
}
