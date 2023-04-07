using Domein.Models;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.CrudOperations
{
    public class SubjectTest 
    {
        private static readonly KundalikDbContext _dbContext = new KundalikDbContext();

        public static async Task<bool> SubjectAddAsync(Subject obj)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Subjects.AddAsync(obj);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public static async Task<bool> SubjectAddRageAsync(List<Subject> obj)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Subjects.AddRageAsync(obj);
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
                bool isCreated = await _dbContext.Subjects.DeleteAsync(id);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<IEnumerable<Subject>> SubjectGetAllAsync()
        {
            try
            {
                KundalikDbContext.CerateDb();
                IEnumerable<Subject> isCreated = await _dbContext.Subjects.GetAllAsync();
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<Subject> SubjectGetByIdAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                Subject isCreated = await _dbContext.Subjects.GetByIdAsync(id);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<bool> SubjectUpdateAsync(Subject entity)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Subjects.UpdateAsync(entity);
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
