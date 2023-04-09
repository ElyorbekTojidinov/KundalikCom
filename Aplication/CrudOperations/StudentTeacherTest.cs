using Domein.Models;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.CrudOperations
{
    public class StudentTeacherTest
    {
        private static readonly KundalikDbContext _dbContext= new KundalikDbContext();
   
        public static async Task<bool> AddAsync(StudentTeacher obj)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.StudentTeachers.AddAsync(obj);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<bool> AddRageAsync(List<StudentTeacher> obj)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.StudentTeachers.AddRageAsync(obj);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.StudentTeachers.DeleteAsync(id);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<IEnumerable<StudentTeacher>> GetAllAsync()
        {
            try
            {
                KundalikDbContext.CerateDb();
                IEnumerable<StudentTeacher> isCreated = await _dbContext.StudentTeachers.GetAllAsync();
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<StudentTeacher> GetByIdAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                StudentTeacher isCreated = await _dbContext.StudentTeachers.GetByIdAsync(id);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<bool> UpdateAsync(StudentTeacher entity)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.StudentTeachers.UpdateAsync(entity);
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
