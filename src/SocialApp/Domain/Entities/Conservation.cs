
using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Conservation:Entity
    {
        public virtual ICollection<User> Members { get; set; }
        public Conservation()
        {
            Members = new HashSet<User>();
    }
        public Conservation(int id) :base(id) 
        {
            Id= id;
        }
    }
}
