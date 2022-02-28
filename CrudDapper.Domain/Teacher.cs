using System.Collections.Generic;

namespace CrudDapper.Domain
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public virtual ICollection<Group> Groups { get; set;  }

        public Subject Subject { get; set; }

        public Teacher()
        {
            Groups = new List<Group>();
        }
    }
}
