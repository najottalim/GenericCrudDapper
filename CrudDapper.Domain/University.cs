using System.Collections.Generic;

namespace CrudDapper.Domain
{
    public class University
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Group> Groups { get; set; }

        public University()
        {
            Groups = new List<Group>();
        }
    }
}
