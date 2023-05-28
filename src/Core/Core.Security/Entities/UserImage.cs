using Core.FileStorage;

namespace Core.Security.Entities
{
    public class UserImage : Files
    {
        public string Name { get; set; }
        //public int? UserId { get; set; }
        //public virtual User User { get; set; }
        public string Path { get; set; }
        public UserImage()
        {

        }

        public UserImage(int id, string name,  string path, string storage) : this()
        {
            Id = id;
            Name = name;
           // UserId = userId;
            Path = path;
            Storage = storage;
        }
    }
}

