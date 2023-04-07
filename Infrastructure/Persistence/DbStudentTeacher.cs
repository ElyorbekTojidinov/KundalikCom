using Domein.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbStudentTeacher : IRepasitory<StudentTeacher>
    {
        private readonly string _connectionString = KundalikDbContext.conString;

        public async Task<bool> AddAsync(StudentTeacher obj)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"insert into StudentTeacher(student_id, teacher_id, subject_id)
                            values(@student_id, @teacher_id, @subject_id)";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@student_id", obj.StudentId);
            cmd.Parameters.AddWithValue("@teacher_id", obj.TeacherId);
            cmd.Parameters.AddWithValue("@subject_id", obj.SubjectId);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AddRageAsync(List<StudentTeacher> obj)
        {
            try
            {
                foreach (StudentTeacher st in obj)
                {
                    await AddAsync(st);

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
            string cmdText = @"dalete from student_teacher where id = @id";
            NpgsqlCommand command = new(cmdText, connection);
            command.Parameters.AddWithValue("@id", id);

            int res = await command.ExecuteNonQueryAsync();
            if (res > 0)
            {
                return true;
            }
            else return false;
        }

        public async Task<IEnumerable<StudentTeacher>> GetAllAsync()
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from student_teacher";
            NpgsqlCommand cmd = new(cmdText, connection);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<StudentTeacher> student_teachers = new List<StudentTeacher>();
            while (reader.Read())
            {
                student_teachers.Add(new()
                {
                    Id = (int)reader["id"],
                    StudentId = await new DbStudents().GetByIdAsync((int)reader["student_id"]),
                    TeacherId = await new DbTeacher().GetByIdAsync((int)reader["teacher_id"]),
                    SubjectId = await new DbSubject().GetByIdAsync((int)reader["subject_id"])
                });
            }
            return student_teachers;
        }

        public async Task<StudentTeacher> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from studet_teacher where id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            StudentTeacher student_teachers = new()
            {
                Id = (int)reader["id"],
                StudentId = await new DbStudents().GetByIdAsync((int)reader["student_id"]),
                TeacherId = await new DbTeacher().GetByIdAsync((int)reader["teacher_id"]),
                SubjectId = await new DbSubject().GetByIdAsync((int)reader["subject_id"])
            };

            return student_teachers;
        }

        public async Task<bool> UpdateAsync(StudentTeacher entity)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"update student_teacher set student_id=@StudentId, teacher_id=@TeacherId, subject_id=@SubjectId
                               where  id= @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@StudentId", entity.StudentId.StudentId);
            cmd.Parameters.AddWithValue("@TeacherId", entity.TeacherId.TeacherId);
            cmd.Parameters.AddWithValue("@SubjectId", entity.SubjectId.SubjectId);
            cmd.Parameters.AddWithValue("@id", entity.Id);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                
                return true;
            }
            
            return false;
        }
    }
}
