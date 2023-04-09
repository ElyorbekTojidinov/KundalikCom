using Domein.Models;
using Infrastructure.Persistence;
using KundalikCom.UI_Form;

namespace KundalikCom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Student_UI.Run();  // ok
            //Teacher_UI.Run();  // ok
            //Subject_UI.Run(); // ok
            //Grade_UI.Run();
            StudentTeacher_UI.Run();

            //Run();

        }
        public async static void Run()
        {





            //KundalikDbContext.CerateDb();
            // KundalikDbContext.
           // DbStudents stDb = new DbStudents();
            //Student st = new()
            //{
            //    FullName = "Tojidinov Bek",
            //    BirthDate = DateTime.Parse("1998.10.29"),
            //    Gender = true,
            //    StudentId = 3,
            //};
            // await stDb.Create(st);

            //stDb.DeleteAsync(1);
            //Console.ReadKey();

            //stDb.UpdateAsync(st);
          //  stDb.GetByIdAsync(3);
           //IEnumerable<Student> res = await stDb.GetAllAsync();

           // foreach (var item in res)
           // {
           //     Console.WriteLine(item);
           // }
        }
        
    }
}