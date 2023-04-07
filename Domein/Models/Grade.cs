using Domein.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domein.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public required StudentTeacher StudentTeacherId { get; set; }
        public GradeEnum GradeEnum { get; set; }
        public DateTime Date { get; set; }

       

        public override string ToString()
        {
            return $"GradeId: {GradeId}, StudentTeacherId: {StudentTeacherId}, GradeEnum: {GradeEnum}, Date: {Date}";
        }
    }
    

}
