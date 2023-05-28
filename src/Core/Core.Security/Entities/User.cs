using Core.Persistence.Repositories;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public int? UserImageId { get; set; }
        public virtual Follow Follow { get; set; }
        public int? FollowId { get; set; }

        public virtual UserImage UserImage { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        public User()
        {

            RefreshTokens = new HashSet<RefreshToken>();
            //UserImage=new HashSet<UserImage>();
           
        }

        public User(
            int id,
            string firstName,
            string lastName,
            string email,
            byte[] passwordSalt,
            byte[] passwordHash,
            bool status,
            AuthenticatorType authenticatorType,
            int followId,
            UserImage userImage

        )
            : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
            AuthenticatorType= authenticatorType;
            FollowId= followId;
            UserImage= userImage;
        }
    }
}
