using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetListUser;

public class GetListUserQuery : IRequest<UserListModel>
{
  
    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            List<User?> users = (List<User?>)await _userRepository.GetAllAsync();
            UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);
            return mappedUserListModel;
        }
    }
}