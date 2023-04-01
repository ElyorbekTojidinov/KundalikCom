using Domein.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    internal class DbSubject : IRepasitory<Subject>
    {
        private readonly string _connectionString = KundalikDbContext.conString;

        public async Task Create(Subject obj)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"insert into subject(subject_name)
                            values(@subject_name)";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@subject_name", obj.SubjectName);
           
            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine(" added sucsesfully");
            }
        }

        public async Task DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"dalete from subject where subject_id = @id";
            NpgsqlCommand command = new(cmdText, connection);
            command.Parameters.AddWithValue("@id", id);

            int res = await command.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine("Delete succesfully");
            }
            else Console.WriteLine("Delted failed");
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from subject";
            NpgsqlCommand cmd = new(cmdText, connection);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<Subject> subjects = new List<Subject>();
            while (reader.Read())
            {
                subjects.Add(new()
                {
                    SubjectId = (int)reader["subject_id"],
                    SubjectName = reader["subject_name"]?.ToString()
                });
            }
            return subjects;
        }

        public async Task<Subject> GetAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from subject where subject_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            Subject teacher = new()
            {
                SubjectId = (int)reader["subject_id"],
                SubjectName = reader["subject_name"]?.ToString()
            };

            return teacher;
        }

        public async Task<bool> UpdateAsync(Subject entity)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"update subject set subject_name=@name
                               where subject_id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@subject_name", entity.SubjectName);
            cmd.Parameters.AddWithValue("@id", entity.SubjectId);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine(entity.SubjectName + " updated succesfully");
                return true;
            }
            Console.WriteLine(entity.SubjectName + " update failed");
            return false;
        }
    }
}
