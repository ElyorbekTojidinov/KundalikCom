using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Models
{
    public class Teacher :Person
    {
        public int TeacherId { get; set; }
        public override string ToString()
        {
            return $"TeacherId: {TeacherId}, FullName: {FullName}, BirthDate: {BirthDate}, Gender: {Gender}";

        }
    }
}
