using Domein.Models;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.CrudOperations
{
    public class TeacherTest
    {
        private static readonly KundalikDbContext _dbContext = new KundalikDbContext();

        public static async Task<bool> SubjectAddAsync(Teacher obj)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Teachers.AddAsync(obj);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public static async Task<bool> SubjectAddRageAsync(List<Teacher> obj)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Teachers.AddRageAsync(obj);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<bool> SubjectDeleteAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Teachers.DeleteAsync(id);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<IEnumerable<Teacher>> SubjectGetAllAsync()
        {
            try
            {
                KundalikDbContext.CerateDb();
                IEnumerable<Teacher> isCreated = await _dbContext.Teachers.GetAllAsync();
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<Teacher> SubjectGetByIdAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                Teacher isCreated = await _dbContext.Teachers.GetByIdAsync(id);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<bool> SubjectUpdateAsync(Teacher entity)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Teachers.UpdateAsync(entity);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
