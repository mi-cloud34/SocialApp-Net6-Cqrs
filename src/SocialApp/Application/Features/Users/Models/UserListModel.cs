using Application.Features.Users.Dtos;

namespace Application.Features.Users.Models;

public class UserListModel 
{
    public IList<Dtos.UserListDto> Items { get; set; }
}