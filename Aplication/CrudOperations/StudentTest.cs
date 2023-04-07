using Domein.Models;
using Infrastructure.Persistence;

namespace Aplication.CrudOperations
{

    public class StudentTest
    {
        private static KundalikDbContext _dbContext = new KundalikDbContext();
        public static async Task<bool> AddStudentAsync(Student student)
        {

            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Students.AddAsync(student);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
        public static async Task<bool> StudentAddRangeAsync(List<Student> students)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Students.AddRageAsync(students);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static async Task<bool> StudentDeleteAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool isCreated = await _dbContext.Students.DeleteAsync(id);
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async static Task<IEnumerable<Student>> GetAllAsync()
        {
            IEnumerable<Student> isCreated = null;
            try
            {
                KundalikDbContext.CerateDb();
                isCreated = await _dbContext.Students.GetAllAsync();
                return isCreated;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return isCreated;
            }
        }

        public async static Task<Student> GetByIdAsync(int id)
        {
            try
            {
                KundalikDbContext.CerateDb();
                Student result = await _dbContext.Students.GetByIdAsync(id);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async static Task<bool> UpdateAsync(Student entity)
        {
            try
            {
                KundalikDbContext.CerateDb();
                bool result = await _dbContext.Students.UpdateAsync(entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
