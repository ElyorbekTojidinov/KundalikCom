using Domein.Models;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.CrudOperations
{
    public class GreadeTest 
    {
        private static KundalikDbContext _context = new();

        public static async Task<bool> GradeAddAsync(Grade obj)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _context.Grades.AddAsync(obj);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<bool> GradeAddRageAsync(List<Grade> obj)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool res = await _context.Grades.AddRageAsync(obj);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<bool> GradeDeleteAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool res = await _context.Grades.DeleteAsync(id);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<IEnumerable<Grade>> GradeGetAllAsync()
        {
            try
            {
                KundalikDbContext.CerateDb();
                IEnumerable<Grade> res = await _context.Grades.GetAllAsync();
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<Grade> GradeGetByIdAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                Grade res = await _context.Grades.GetByIdAsync(id);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<bool> GradeUpdateAsync(Grade entity)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool res = await _context.Grades.UpdateAsync(entity);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
