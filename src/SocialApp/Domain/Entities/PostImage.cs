using Core.FileStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostImage: Files
    {
        public string Name { get; set; }
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
        public string Path { get; set; }
        public PostImage()
        {

        }

        public PostImage(int id, string name, int postId, string path, string storage) : this()
        {
            Id = id;
            Name = name;
            PostId = postId;
            Path = path;
            Storage = storage;
        }
    }
}

