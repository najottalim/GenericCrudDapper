using System.Collections.Generic;

namespace CrudDapper.Domain
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; }

        public Subject()
        {
            Teachers = new List<Teacher>();
        }
    }
}
