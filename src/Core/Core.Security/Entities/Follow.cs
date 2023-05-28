using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class Follow : Entity
    {
        public virtual ICollection<User> Following { get; set; }
        public virtual ICollection<User> Followers { get; set; }
        public Follow()
        {
            Followers = new HashSet<User>();
            Following = new HashSet<User>();
        }
        public Follow(int id) : base(id)
        {
            Id = id;
        }
    }
}
