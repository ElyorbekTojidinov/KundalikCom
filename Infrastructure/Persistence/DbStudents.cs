using Domein.Models;
using Npgsql;

namespace Infrastructure.Persistence
{
    public class DbStudents : IRepasitory<Student>
    {
        private static readonly string _connectionString = KundalikDbContext.conString;

        public async Task<bool> AddAsync(Student obj)
        {
            try
            { 
                using NpgsqlConnection connection = new(_connectionString);
                connection.Open();
                string cmdText = @"insert into student(student_name, birth_date, gender)
                            values(@student_name, @birth_date, @gender)";
                NpgsqlCommand cmd = new(cmdText, connection);
                cmd.Parameters.AddWithValue("@student_name", obj.FullName);
                cmd.Parameters.AddWithValue("@birth_date", obj.BirthDate);
                cmd.Parameters.AddWithValue("@gender", obj.Gender);

                int res = await cmd.ExecuteNonQueryAsync();
                Console.WriteLine(res);
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;

            }
        }

        public  async Task<bool> AddRageAsync(List<Student> obj)
        {
            try
            {

                foreach (Student students in obj)
                {
                    await AddAsync(students);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public  async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using NpgsqlConnection connection = new(_connectionString);
                connection.Open();
                string cmdText = @"delete from student where student_id = @id";
                NpgsqlCommand command = new(cmdText, connection);
                command.Parameters.AddWithValue("@id", id);

                int res = await command.ExecuteNonQueryAsync();
               
                if (res > 0)
                {
                    return true;
                }
                else return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            try
            {
                await using NpgsqlConnection connection = new(_connectionString);
                connection.Open();
                string cmdText = @"select * from student";
                NpgsqlCommand cmd = new(cmdText, connection);

                NpgsqlDataReader reader = cmd.ExecuteReader();
                ICollection<Student> students = new List<Student>();
                while (reader.Read())
                {
                    students.Add(new()
                    {
                        StudentId = (int)reader["student_id"],
                        FullName = reader["student_name"]?.ToString(),
                        BirthDate = DateTime.Parse(reader["birth_date"]?.ToString()),
                        Gender = (bool)reader["gender"]
                    });
                }
                return students;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }



        public async Task<Student> GetByIdAsync(int id)
        {

            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from student where student_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader =  cmd.ExecuteReader();
            Student student = null;
            while (reader.Read())
            {
                student = new()
                {
                    StudentId = (int)reader["student_id"],
                    FullName = reader["student_name"].ToString(),
                    BirthDate = DateTime.Parse(reader["birth_date"].ToString()),
                    Gender = (bool)reader["gender"]
                };
            }

            return student;

        }

        public async Task<bool> UpdateAsync(Student entity)
        {
            try
            {
                using NpgsqlConnection connection = new(_connectionString);
                connection.Open();
                string cmdText = @"update student set student_name=@name, birth_date=@birth_date, gender=@gender
                               where student_id = @id;";
                NpgsqlCommand cmd = new(cmdText, connection);
                cmd.Parameters.AddWithValue("@name", entity.FullName);
                cmd.Parameters.AddWithValue("@birth_date", entity.BirthDate);
                cmd.Parameters.AddWithValue("@gender", entity.Gender);
                cmd.Parameters.AddWithValue("@id", entity.StudentId);

                int res = await cmd.ExecuteNonQueryAsync();
                if (res > 0)
                {
                   
                    return true;
                }
                
                return false;
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception);
                return false;
            }
        }
    }
}
