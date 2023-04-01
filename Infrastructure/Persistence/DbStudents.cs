using Domein.Models;
using Npgsql;

namespace Infrastructure.Persistence
{
    public class DbStudents : IRepasitory<Student>
    {
        private readonly string _connectionString = KundalikDbContext.conString;
        public async Task Create(Student obj)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"insert into student(full_name, birth_date, gender)
                            values(@name, @birth_date, @gender)";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", obj.FullName);
            cmd.Parameters.AddWithValue("@birth_date", obj.BirthDate);
            cmd.Parameters.AddWithValue("@gender", obj.Gender);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine(obj.FullName + " added sucsesfully");
            }
        }


        public async Task DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"dalete from student where student_id = @id";
            NpgsqlCommand command = new(cmdText, connection);
            command.Parameters.AddWithValue("@id", id);

            int res = await command.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine("Delete succesfully");
            }
            else Console.WriteLine("Delted failed");

        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from student";
            NpgsqlCommand cmd = new(cmdText, connection);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<Student> students = new List<Student>();
            while (reader.Read())
            {
                students.Add(new()
                {
                    StudentId = (int)reader["student_id"],
                    FullName = reader["student_name"]?.ToString(),
                    BirthDate = DateOnly.Parse(reader["birth_date"]?.ToString()),
                    Gender = (bool)reader["gender"]
                });
            }
            return students;
        }

        public async Task<Student> GetAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from student where student_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            Student student = new()
            {
                StudentId = (int)reader["student_id"],
                FullName = reader["student_name"].ToString(),
                BirthDate = DateOnly.Parse(reader["birth_date"].ToString()),
                Gender = (bool)reader["gender"]
            };

            return student;
        }

        public async Task<bool> UpdateAsync(Student entity)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"update student set full_name=@name, birth_date=@birth_date, gender=@gender
                               where student_id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", entity.FullName);
            cmd.Parameters.AddWithValue("@birth_date", entity.BirthDate);
            cmd.Parameters.AddWithValue("@gender", entity.Gender);
            cmd.Parameters.AddWithValue("@id", entity.StudentId);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine(entity.FullName + " updated succesfully");
                return true;
            }
            Console.WriteLine(entity.FullName + " update failed");
            return false;
        }
    }
}
