

using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post:Entity
    {
        public string Description { get; set; }
        public virtual ICollection<User> Likes { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
       // public int? PostImageId { get; set; }
        public virtual ICollection<PostImage> PostImages { get; set; }
        public string PostText { get; set; }
        public Post()
        {
            PostImages = new HashSet<PostImage>();
            Likes =new HashSet<User>();
        }
    

        public Post(int id, string postText, int userId, string description) : this()
        {
            Id = id;
            PostText = postText;
            Description= description;
            UserId = userId;
        }
    }
}
