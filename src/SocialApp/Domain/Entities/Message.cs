

using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message:Entity
    {
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public string MessageText { get; set; }
        public Message()
        {

        }

        public Message(int id, string text, int userId) : this()
        {
            Id = id;
            UserId = userId;
            MessageText= text;
        }
    }
}
