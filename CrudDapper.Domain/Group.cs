using System.Collections.Generic;

namespace CrudDapper.Domain
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public University University { get; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Group()
        {
            Teachers = new List<Teacher>();

            Students = new List<Student>();
        }
    }
}
