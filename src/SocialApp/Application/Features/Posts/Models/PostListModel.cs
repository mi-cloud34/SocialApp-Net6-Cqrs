using Application.Features.Users.Dtos;

namespace Application.Features.Posts.Models;

public class PostListModel
{
    public IList<Dtos.PostListDto> Items { get; set; }
}