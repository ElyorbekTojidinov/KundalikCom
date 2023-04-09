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
    public class Teacher_UI
    {
        public static void Run()
        {
        numKey:
            Console.WriteLine("1 Add Teachers");
            Console.WriteLine("2 Read Teachers");
            Console.WriteLine("3 ReadById Teachers");
            Console.WriteLine("4 Update Teacher");
            Console.WriteLine("5 Delete Teacher");
            if (!byte.TryParse(Console.ReadLine(), out byte num))
            {
                goto numKey;
            }
            switch (num)
            {
                case 1: AddTeacher(); break;
                case 2: ReadAllTeacher(); break;
                case 3: ReadByIdTeacher(); break;
                case 4: UpdateTeacher(); break;
                case 5: DeleteTeacher(); break;

                default: goto numKey;
            }
            Console.ReadKey();
        }
        public static async void AddTeacher()
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


            Teacher std = new()
            {
                FullName = name,
                BirthDate = birthDate,
                Gender = gender
            };

            bool res = await TeacherTest.SubjectAddAsync(std);

            Methods.BoolMethod(res);
        }

        public static async void ReadAllTeacher()
        {
            IEnumerable<Teacher> teachers = await TeacherTest.SubjectGetAllAsync();
            foreach (Teacher teacher in teachers)
            {
                Console.WriteLine(teacher);
            }
        }
        public static async void ReadByIdTeacher()
        {
        ret:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto ret;
            }
            else
            {
                Teacher std = await TeacherTest.SubjectGetByIdAsync(id);
                Console.WriteLine(std);
            }
        }
        public static async void UpdateTeacher()
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

            Teacher std = new()
            {
                TeacherId = id,
                FullName = name,
                BirthDate = birthDate,
                Gender = gender
            };


            bool res = await TeacherTest.SubjectUpdateAsync(std);

            Methods.BoolMethod(res);
        }
        public static async void DeleteTeacher()
        {
        Idkey:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto Idkey;
            }
            bool res = await TeacherTest.SubjectDeleteAsync(id);

            Methods.BoolMethod(res);
        }
    }
}
