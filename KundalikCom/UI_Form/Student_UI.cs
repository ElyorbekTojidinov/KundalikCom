using Aplication.CrudOperations;
using Domein.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KundalikCom.UI_Form
{
    public class Student_UI
    {
        public static void Run()
        {
            numKey:
            Console.WriteLine("1 Add Students");
            Console.WriteLine("2 Read Students");
            Console.WriteLine("3 ReadById Students");
            Console.WriteLine("4 Update Student");
            Console.WriteLine("5 Delete Student");
            if(!byte.TryParse(Console.ReadLine(), out byte num))
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
            if(name == null)
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
            if(!int.TryParse(Console.ReadLine(), out int id))
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
                StudentId= id,
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
