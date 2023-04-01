using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class KundalikDbContext
    {
        public static string conString = File.ReadAllText(@"..\..\..\..\..\KundalikCom\Infrastructure\Persistence\AppConfig.txt");

        public static void InitializeTable()
        {
            try
            {
                using NpgsqlConnection connection= new NpgsqlConnection(conString);
                connection.Open();
                string query = @"create table student 
                                (
                                    student_id serial not null,
                                    student_name character varying(50) not null,
                                    birth_date date ,
                                    gender boolean default true,
                                    primary key (student_id)
                                 );
                                 CREATE TABLE teacher
                                (
                                    teacher_id serial NOT NULL,
                                    teacher_name character varying(50) NOT NULL,
                                    birth_date date,
                                    gender boolean DEFAULT true,
                                    PRIMARY KEY (teacher_id)
                                );
                                CREATE TABLE subject
                                (
                                    subject_id serial NOT NULL,
                                    subject_name character varying(50) NOT NULL,
                                    PRIMARY KEY (subject_id)
                                );
                                CREATE TABLE student_teacher
                                (
                                    id serial NOT NULL,
                                    student_id integer references student(student_id) NOT NULL,
                                    teacher_id integer references teacher(teacher_id) NOT NULL,
                                    subject_id integer references subject(subject_id) NOT NULL,
                                    PRIMARY KEY (id)
                                );
                                CREATE TABLE grade
                                (
                                    grade_id serial NOT NULL,
                                    grade_rate integer NOT NULL,
                                    grade_date date,
                                    student_teacher_id integer references student_teacher(id) NOT NULL,
                                    PRIMARY KEY (grade_id)
                                );";
                NpgsqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }

        public static void CerateDb()
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(conString);
                connection.Open();
                connection.Close();

            }catch(NpgsqlException e)
            {
                if(e.Message.Contains("does not exist", StringComparison.OrdinalIgnoreCase))
                {
                  string  constr2 = conString.Replace("kundalik", "postgres");
                    using NpgsqlConnection connection = new NpgsqlConnection(constr2);
                    connection.Open();
                    string query = "create database kundalik";
                    NpgsqlCommand command = new(query, connection);
                    command.ExecuteNonQuery();
                    InitializeTable();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public DbStudents Students { get; set; }
    }
}
