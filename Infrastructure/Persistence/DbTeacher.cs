using Domein.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbTeacher : IRepasitory<Teacher>
    {
        private readonly string _connectionString = KundalikDbContext.conString;
        public async Task Create(Teacher obj)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"insert into teacher(full_name, birth_date, gender)
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
            string cmdText = @"dalete from teacher where teacher_id = @id";
            NpgsqlCommand command = new(cmdText, connection);
            command.Parameters.AddWithValue("@id", id);

            int res = await command.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine("Delete succesfully");
            }
            else Console.WriteLine("Delted failed");
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from teacher";
            NpgsqlCommand cmd = new(cmdText, connection);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                teachers.Add(new()
                {
                    TeacherId = (int)reader["teacher_id"],
                    FullName = reader["teacher_name"]?.ToString(),
                    BirthDate = DateOnly.Parse(reader["birth_date"]?.ToString()),
                    Gender = (bool)reader["gender"]
                });
            }
            return teachers;
        }

        public async Task<Teacher> GetAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from teacher where teacher_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            Teacher teacher = new()
            {
                TeacherId = (int)reader["teacher_id"],
                FullName = reader["teacher_name"].ToString(),
                BirthDate = DateOnly.Parse(reader["birth_date"].ToString()),
                Gender = (bool)reader["gender"]
            };

            return teacher;
        }

        public async Task<bool> UpdateAsync(Teacher entity)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"update teacher set full_name=@name, birth_date=@birth_date, gender=@gender
                               where teacher_id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@name", entity.FullName);
            cmd.Parameters.AddWithValue("@birth_date", entity.BirthDate);
            cmd.Parameters.AddWithValue("@gender", entity.Gender);
            cmd.Parameters.AddWithValue("@id", entity.TeacherId);

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
