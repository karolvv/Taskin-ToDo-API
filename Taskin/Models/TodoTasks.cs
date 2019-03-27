using System.ComponentModel.DataAnnotations;

namespace Taskin.Models
{
    public class TodoTasks
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Range(1,3)]
        public int Priority { get; set; }
    }
}