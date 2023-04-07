using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein.Models
{
    public class Person
    {
        public required string  FullName { get; set; }
        public DateTime  BirthDate { get; set; }
        /// <summary>
        /// True = Male 
        /// False = Female
        /// 
        /// </summary>
        public bool Gender { get; set; } = true;

    }
}
