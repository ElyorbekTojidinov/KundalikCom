using Domein.Models;
using Infrastructure.Persistence;

namespace KundalikCom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            KundalikDbContext.CerateDb();
           // KundalikDbContext.
            DbStudents stDb = new DbStudents();
            //Student st = new(
            //    { FullName = "Tojidinov Elyorbek",
            //    BirthDate = "1998.10.29", 
            //    Gender = false });
            //stDb.Create(st);
        
        
        }
    }
}