using System.ComponentModel.DataAnnotations;

namespace Taskin.Models
{
    public class Task
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,3)]
        public int Priority { get; set; }
    }
}