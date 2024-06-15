using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public required int ProjectId { get; set; }
    }
}
