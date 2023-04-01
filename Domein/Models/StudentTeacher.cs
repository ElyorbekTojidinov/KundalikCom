using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Models
{
    public class StudentTeacher
    {
        public int Id { get; set; }
        public required Student StudentId { get; set; }
        public required Teacher TeacherId { get; set; }
        public required Subject SubjectId { get; set; }
    }
}
