using CrudDapper.Data.IRepositories;
using CrudDapper.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDapper.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public async Task<IEnumerable<Student>> GetAllAsync(Func<Student, bool> predicate = null)
        {

            var students = await _db.QueryAsync<Student, Group, Student>(
                $"SELECT st.*, gr.* FROM Students as st " +
                $"INNER JOIN Groups as gr on gr.id = st.GroupId;", (st, gr) =>
                {
                    Student student = st;

                    gr.Students.Add(student);
                    student.Group = gr;

                    return student;
                });
            return predicate == null ? students : students.Where(predicate);
        }

        public async Task<Student> GetAsync(int id)
        {
            var students = await _db.QueryAsync<Student, Group, Student>(
                $"SELECT st.*, gr.* FROM Students as st " +
                $"INNER JOIN Groups as gr on gr.id = st.GroupId;", (st, gr) =>
                {
                    Student student = st;

                    gr.Students.Add(student);
                    student.Group = gr;

                    return student;
                });
            return students.FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
