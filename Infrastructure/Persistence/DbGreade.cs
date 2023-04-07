using Domein.Models;
using Domein.States;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbGreade : IRepasitory<Grade>
    {
        private readonly string _connectionString = KundalikDbContext.conString;
       
        public async Task<bool> AddAsync(Grade obj)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"insert into grade(grade_rate,grade_date, student_teacher_id) 
                    values (@name, @birth_date, @gender)";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@grade_rate", obj.GradeEnum);
            cmd.Parameters.AddWithValue("@grade_date", obj.Date);
            cmd.Parameters.AddWithValue("@student_teacher_id", obj.StudentTeacherId.Id);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                Console.WriteLine("grade added succesfully");
                return true;
            }
            return false;
        }

        public async Task<bool> AddRageAsync(List<Grade> obj)
        {
            try
            {
                foreach (Grade grade in obj)
                {
                    await AddAsync(grade);

                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"delete from grade where grade_id=@id";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                return true;
            }
            else return false;
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"select * from grade";
            NpgsqlCommand cmd = new(cmdText, connection);

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            ICollection<Grade> grades = new List<Grade>();
            while (reader.Read())
            {
                grades.Add(new()
                {
                    GradeId = (int)reader["grade_id"],
                    GradeEnum = Enum.Parse<GradeEnum>(reader["grade_rate"]?.ToString()),
                    StudentTeacherId = (StudentTeacher)reader["student_teacher_id"],
                    Date = (DateTime)reader["grade_date"]
                });
            }
            return grades;
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            using NpgsqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            string cmdText = @"select * from grade where grade_id=@id";
            using NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                Grade grade = new()
                {
                    GradeId = (int)reader["grade_id"],
                    GradeEnum = Enum.Parse<GradeEnum>(reader["grade_rate"].ToString()),
                    StudentTeacherId = (StudentTeacher)reader["student_teacher_id"],
                    Date = (DateTime)reader["grade_date"]
                };
                return grade;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Grade entity)
        {
            using NpgsqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"update grade set grade_rate=@grade_rate, grade_date=@grade_date, student_teacher_id=@student_teacher_id
                               where teacher_id = @id;";
            NpgsqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@grade_rate", entity.GradeEnum);
            cmd.Parameters.AddWithValue("@grade_date", entity.Date);
            cmd.Parameters.AddWithValue("@student_teacher_id", entity.StudentTeacherId.Id);
            int res = await cmd.ExecuteNonQueryAsync();
            if (res > 0)
            {
                
                return true;
            }
            
            return false;
        }
    }
}
