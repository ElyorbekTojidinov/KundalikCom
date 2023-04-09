using Domein.Models;
using Npgsql;

namespace Infrastructure.Persistence
{
    public class DbSubject : IRepasitory<Subject>
    {
        private readonly string _connectionString = KundalikDbContext.conString;

        public async Task<bool> AddAsync(Subject obj)
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
                return true;
            }
            return false;
        }

        public async Task<bool> AddRageAsync(List<Subject> obj)
        {
            try
            {
                foreach (Subject subjects in obj)
                {
                    await AddAsync(subjects);
                }
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"delete from subject where subject_id = @id";
            NpgsqlCommand command = new(cmdText, connection);
            command.Parameters.AddWithValue("@id", id);

            int res = await command.ExecuteNonQueryAsync();
            if (res > 0)
            {
                return true;
            }
            else return false;
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

        public async Task<Subject> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from subject where subject_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            Subject? teacher = null;
            while (reader.Read())
            {
                teacher = new Subject()
                {
                    SubjectId = (int)reader["subject_id"],
                    SubjectName = reader["subject_name"]?.ToString()
                };
            }

            return teacher;
        }

        public async Task<bool> UpdateAsync(Subject entity)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"update subject set subject_name=@subject_name
                               where subject_id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@subject_name", entity.SubjectName);
            cmd.Parameters.AddWithValue("@id", entity.SubjectId);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }
    }
}
