using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
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
