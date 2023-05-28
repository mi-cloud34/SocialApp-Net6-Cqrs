using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Persistence.Repositories
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Entity()
        {
        }

        public Entity(int id) : this()
        {
            Id = id;


        }
    }

}
