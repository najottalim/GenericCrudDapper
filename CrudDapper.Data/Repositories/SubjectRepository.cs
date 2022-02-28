using CrudDapper.Data.IRepositories;
using CrudDapper.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDapper.Data.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public async Task<IEnumerable<Subject>> GetAllAsync(Func<Subject, bool> predicate = null)
        {

            var subjects = await _db.QueryAsync<Subject,Teacher, Subject>(
                $"SELECT sb.*, tch.* FROM Subjects as sb " +
                $"INNER JOIN Teachers as tch on sb.id = tch.SubjectId", (sb, tch) =>
                {
                    Subject subject = sb;

                    tch.Subject = sb;
                    subject.Teachers.Add(tch);

                    return subject;
                });
            return predicate == null ? subjects : subjects.Where(predicate);
        }

        public async Task<Subject> GetAsync(int id)
        {
            var subjects = await _db.QueryAsync<Subject, Teacher, Subject>(
                $"SELECT sb.*, tch.* FROM Subjects as sb " +
                $"INNER JOIN Teachers as tch on sb.id = tch.SubjectId", (sb, tch) =>
                {
                    Subject subject = sb;

                    tch.Subject = sb;
                    subject.Teachers.Add(tch);

                    return subject;
                });
            return subjects.FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
