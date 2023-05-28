using Application.Features.Conservations.Dtos;

namespace Application.Features.Conservations.Models;

public class ConservationListModel
{
    public IList<ConservationListDto> Items { get; set; }
}