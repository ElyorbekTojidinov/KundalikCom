using Aplication.CrudOperations;
using Domein.Models;
using Domein.States;
using Infrastructure.Persistence;

namespace KundalikCom.UI_Form
{

    public class Grade_UI
    {
        private static GreadeTest _greadeCon = new();

        public static void Run()
        {
        numKey:
            Console.WriteLine("1 Add Greade");
            Console.WriteLine("2 Read Greade");
            Console.WriteLine("3 ReadById Greade");
            Console.WriteLine("4 Update Greade");
            Console.WriteLine("5 Delete Greade");
            if (!byte.TryParse(Console.ReadLine(), out byte num))
            {
                goto numKey;
            }
            switch (num)
            {
                case 1: AddGreade(); break;
                case 2: ReadAll(); break;
                case 3: ReadById(); break;
                case 4: Update(); break;
                case 5: DeleteStudent(); break;

                default: goto numKey;
            }
        }
        public static async void AddGreade()
        {
        namekey:
            Console.WriteLine("StudentTeacherId: ");
            if (int.TryParse(Console.ReadLine(), out int stId))
            {
                goto namekey;
            }
        key:
           
            Console.WriteLine("1: F = 0,\r\n       2: E = 1,\r\n       3: D = 2,\r\n       4: C = 3,\r\n       5: B = 4,\r\n        6: A= 5 ");
            Console.WriteLine("Grade: ");
            string grade;
            if (!int.TryParse(Console.ReadLine(), out int grade1))
            {
                goto key;
            }
            else
            {
                switch (grade1)
                {
                    case 1: grade = "F"; break;
                    case 2: grade = "E"; break;
                    case 3: grade = "D"; break;
                    case 4: grade = "C"; break;
                    case 5: grade = "B"; break;
                    case 6: grade = "D"; break;
                        default : goto key;
                }
            }
        
            Grade grd = new()
            {
                StudentTeacherId = await StudentTeacherTest.GetByIdAsync(stId),
                Date= DateTime.Now,
                GradeEnum = Enum.Parse<GradeEnum>(grade)
            };

            bool res = await GreadeTest.GradeAddAsync(grd);

            Methods.BoolMethod(res);
        }

        public static async void ReadAll()
        {
            IEnumerable<Grade> grades = await GreadeTest.GradeGetAllAsync();
            foreach (Grade item in grades)
            {
                Console.WriteLine(item);
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
                Grade gr = await GreadeTest.GradeGetByIdAsync(id);
                Console.WriteLine(gr);
            }
        }
        public static async void Update()
        {

        namekey:
            Console.WriteLine("StudentTeacherId: ");
            if (int.TryParse(Console.ReadLine(), out int stId))
            {
                goto namekey;
            }
        key:

            Console.WriteLine("1: F = 0,\r\n       2: E = 1,\r\n       3: D = 2,\r\n       4: C = 3,\r\n       5: B = 4,\r\n        6: A= 5 ");
            Console.WriteLine("Grade: ");
            string grade;
            if (!int.TryParse(Console.ReadLine(), out int grade1))
            {
                goto key;
            }
            else
            {
                switch (grade1)
                {
                    case 1: grade = "F"; break;
                    case 2: grade = "E"; break;
                    case 3: grade = "D"; break;
                    case 4: grade = "C"; break;
                    case 5: grade = "B"; break;
                    case 6: grade = "D"; break;
                    default: goto key;
                }
            }

            Grade grd = new()
            {
                StudentTeacherId = await StudentTeacherTest.GetByIdAsync(stId),
                Date = DateTime.Now,
                GradeEnum = Enum.Parse<GradeEnum>(grade)
            };

            bool res = await GreadeTest.GradeUpdateAsync(grd);

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
            bool res = await GreadeTest.GradeDeleteAsync(id);

            Methods.BoolMethod(res);
        }
    }
}
