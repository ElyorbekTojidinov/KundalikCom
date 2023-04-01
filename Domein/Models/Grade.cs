using Domein.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public required StudentTeacher StudentteacherId { get; set; }
        public GradeEnum GradeEnum { get; set; }
        public DateTime Date { get; set; }
    }
}
