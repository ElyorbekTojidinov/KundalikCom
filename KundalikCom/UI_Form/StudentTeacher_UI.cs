using Aplication.CrudOperations;
using Domein.Models;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundalikCom.UI_Form
{
    public class StudentTeacher_UI
    {
        public static void Run()
        {
        numKey:
            Console.WriteLine("1 Add StudentTeacher");
            Console.WriteLine("2 Read StudentTeacher");
            Console.WriteLine("3 ReadById StudentTeacher");
            Console.WriteLine("4 Update StudentTeacher");
            Console.WriteLine("5 Delete StudentTeacher");
            if (!byte.TryParse(Console.ReadLine(), out byte num))
            {
                goto numKey;
            }
            switch (num)
            {
                case 1: AddStudentTeacher(); break;
                case 2: ReadAll(); break;
                case 3: ReadById(); break;
                case 4: Update(); break;
                case 5: DeleteStudent(); break;

                default: goto numKey;
            }
            Console.ReadKey();
        }

        private readonly static DbStudents dbStudents= new DbStudents();
        private readonly static DbTeacher dbTeacher= new();
        private readonly static DbSubject dbSubject= new();

        public static async void AddStudentTeacher()
        {
        namekey:
            Console.WriteLine("Student Id: ");
            if(!int.TryParse(Console.ReadLine(), out int stdId))
            {
                goto namekey;
            }
            
        key:
            Console.WriteLine("Teacher Id: ");
            if (!int.TryParse(Console.ReadLine(), out int techId))
            {
                goto key;
            }
            keySub:
            Console.WriteLine("Subject Id: ");
            if (!int.TryParse(Console.ReadLine(), out int subId))
            {
                goto keySub;
            }

            StudentTeacher st = new StudentTeacher
            {
                StudentId = await  dbStudents.GetByIdAsync(stdId),
                SubjectId = await dbSubject.GetByIdAsync(subId),
                TeacherId = await dbTeacher.GetByIdAsync(techId)
            };
            bool res = await StudentTeacherTest.AddAsync(st);

            Methods.BoolMethod(res);
        }

        public static async void ReadAll()
        {
            IEnumerable<StudentTeacher> students = await StudentTeacherTest.GetAllAsync();
            foreach (StudentTeacher student in students)
            {
                Console.WriteLine(student);
            }
        }

        public static async void ReadById()
        {
        ret:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto ret;
            }
            else
            {
                StudentTeacher std = await StudentTeacherTest.GetByIdAsync(id);
                Console.WriteLine(std);
            }
        }

        public static async void Update()
        {

        namekey:
            Console.WriteLine("Student Id: ");
            if (!int.TryParse(Console.ReadLine(), out int stdId))
            {
                goto namekey;
            }

        key:
            Console.WriteLine("Teacher Id: ");
            if (!int.TryParse(Console.ReadLine(), out int techId))
            {
                goto key;
            }
        keySub:
            Console.WriteLine("Subject Id: ");
            if (!int.TryParse(Console.ReadLine(), out int subId))
            {
                goto keySub;
            }
        Idkey:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto Idkey;
            }

            StudentTeacher st = new StudentTeacher
            {
                Id = id,
                StudentId = await dbStudents.GetByIdAsync(stdId),
                SubjectId = await dbSubject.GetByIdAsync(subId),
                TeacherId = await dbTeacher.GetByIdAsync(techId)
            };
            
            bool res = await StudentTeacherTest.UpdateAsync(st);

            Methods.BoolMethod(res);
        }

        public static async void DeleteStudent()
        {
        Idkey:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto Idkey;
            }
            bool res = await StudentTeacherTest.DeleteAsync(id);

            Methods.BoolMethod(res);
        }
    }
}
