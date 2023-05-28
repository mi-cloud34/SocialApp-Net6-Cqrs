

using Application.Features.Follows.Dtos;

namespace Application.Features.Follows.Models;

public class FollowListModel
{
    public IList<FollowListDto> Items { get; set; }
}