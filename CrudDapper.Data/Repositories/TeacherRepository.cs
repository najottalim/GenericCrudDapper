using CrudDapper.Data.IRepositories;
using CrudDapper.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDapper.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public async Task<IEnumerable<Teacher>> GetAllAsync(Func<Teacher, bool> predicate = null)
        {

            var teachers = await _db.QueryAsync<Teacher, Group, Subject, Teacher>(
                $"SELECT tch.*, gr.*, sb.* FROM GroupTeacher as grtch " +
                $"INNER JOIN Teachers as tch on tch.id = grtch.TeacherId " +
                $"INNER JOIN Groups as gr on gr.id = grtch.GroupId " +
                $"INNER JOIN Subjects as sb on sb.id = tch.SubjectId;", (tch, gr, sb) =>
                {
                    Teacher teacher = tch;

                    teacher.Subject = sb;
                    teacher.Groups.Add(gr);

                    return teacher;
                });
            return predicate == null ? teachers : teachers.Where(predicate);
        }

        public async Task<Teacher> GetAsync(int id)
        {

            var teachers = await _db.QueryAsync<Teacher, Group, Subject, Teacher>(
                $"SELECT tch.*, gr.*, sb.* FROM GroupTeacher as grtch " +
                $"INNER JOIN Teachers as tch on tch.id = grtch.TeacherId " +
                $"INNER JOIN Groups as gr on gr.id = grtch.GroupId " +
                $"INNER JOIN Subjects as sb on sb.id = tch.SubjectId;", (tch, gr, sb) =>
                {
                    Teacher teacher = tch;

                    teacher.Subject = sb;
                    teacher.Groups.Add(gr);

                    return teacher;
                });
            return teachers.FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
