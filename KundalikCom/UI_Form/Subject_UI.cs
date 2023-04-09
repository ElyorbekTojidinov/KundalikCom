using Aplication.CrudOperations;
using Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundalikCom.UI_Form
{
    public class Subject_UI
    {
        public static void Run()
        {
        numKey:
            Console.WriteLine("1 Add Subjects");
            Console.WriteLine("2 Read Subjects");
            Console.WriteLine("3 ReadById Subjects");
            Console.WriteLine("4 Update Subjects");
            Console.WriteLine("5 Delete Subjects");
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
            Console.ReadKey();
        }

        public static async void AddStudent()
        {
        namekey:
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            if (name == null)
            {
                goto namekey;
            }
        
            Subject sb = new()
            {
                SubjectName= name
            };

            bool res = await SubjectTest.SubjectAddAsync(sb);

            Methods.BoolMethod(res);
        }

        public static async void ReadAll()
        {
            IEnumerable<Subject> subjects = await SubjectTest.SubjectGetAllAsync();
            foreach (Subject subject in subjects)
            {
                Console.WriteLine(subject);
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
                Subject std = await SubjectTest.SubjectGetByIdAsync(id);
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
        Idkey:
            Console.WriteLine("Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                goto Idkey;
            }

            Subject sb = new()
            {
                SubjectId = id,
                SubjectName= name
            };


            bool res = await SubjectTest.SubjectUpdateAsync(sb);

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
            bool res = await SubjectTest.SubjectDeleteAsync(id);

            Methods.BoolMethod(res);
        }
    }
}
