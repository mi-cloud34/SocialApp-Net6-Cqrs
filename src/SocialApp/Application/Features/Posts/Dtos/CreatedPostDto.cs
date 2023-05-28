using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Posts.Dtos
{
    public class CreatedPostDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
       
        public int? UserId { get; set; }
      
        public string PostText { get; set; }
    }
}
