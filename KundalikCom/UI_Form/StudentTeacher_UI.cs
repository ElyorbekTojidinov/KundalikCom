using Aplication.CrudOperations;
using Domein.Models;
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
                case 1: AddStudent(); break;
                case 2: ReadAll(); break;
                case 3: ReadById(); break;
                case 4: Update(); break;
                case 5: DeleteStudent(); break;

                default: goto numKey;
            }
        }
        public static async void AddStudentTeacher()
        {
        namekey:
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                goto namekey;
            }
        key:
            Console.WriteLine("BirthDate: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
            {
                goto key;
            }
        genkey:
            Console.WriteLine("Gender: ");
            Console.WriteLine("1 Male");
            Console.WriteLine("2 Female");
            if (!byte.TryParse(Console.ReadLine(), out byte gen))
            {
                goto genkey;
            }
            bool gender;


            switch (gen)
            {
                case 1: gender = true; break;
                case 2: gender = false; break;
                default: goto genkey;
            }


            Student std = new()
            {
                FullName = name,
                BirthDate = birthDate,
                Gender = gender
            };

            bool res = await StudentTest.AddStudentAsync(std);

            Methods.BoolMethod(res);
        }

        public static async void ReadAll()
        {
            IEnumerable<Student> students = await StudentTest.GetAllAsync();
            foreach (Student student in students)
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
                Student std = await StudentTest.GetByIdAsync(id);
                Console.WriteLine(std);
            }
        }
        public static async void Update()
        {

        namekey:
            Console.WriteLine("Name: ");
            string? name = Console.ReadLine();
            if (name == null)
            {
                goto namekey;
            }
        key:
            Console.WriteLine("BirthDate: ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
            {
                goto key;
            }
        genkey:
            Console.WriteLine("Gender: ");
            Console.WriteLine("1 Male");
            Console.WriteLine("2 Female");
            if (!byte.TryParse(Console.ReadLine(), out byte gen))
            {
                goto genkey;
            }
            bool gender;

            switch (gen)
            {
                case 1: gender = true; break;
                case 2: gender = false; break;
                default: goto genkey;
            }
        Idkey:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto Idkey;
            }

            Student std = new()
            {
                StudentId = id,
                FullName = name,
                BirthDate = birthDate,
                Gender = gender
            };


            bool res = await StudentTest.UpdateAsync(std);

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
            bool res = await StudentTest.StudentDeleteAsync(id);

            Methods.BoolMethod(res);
        }
    }
}
