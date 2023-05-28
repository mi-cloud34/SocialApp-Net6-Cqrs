
using Application.Features.Users.Constants;
using Application.Features.Users.Dtos;
using Application.Features.Users.Dtos.EventUserBus;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.FileStorage;
using Core.Security.Entities;
using Core.Security.Hashing;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;
using System.Net.Mail;
using static Application.Features.Users.Constants.OperationClaims;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IFormFile? Files { get; set; }

  
 
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IStorageService _storageServices;
      
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper,
                                        UserBusinessRules userBusinessRules,IStorageService storageService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _storageServices=storageService;
        }

        public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User mappedUser = _mapper.Map<User>(request);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;
           ;
            (string fileName, string pathOrContainerName) result = await _storageServices.UploadAsync("user-files", request.Files);
            mappedUser.UserImage = new UserImage
            {

                Name = result.fileName,
                Path = result.pathOrContainerName,
                Storage = _storageServices.StorageName
                //UserId=mappedUser.Id
            };

            User createdUser = await _userRepository.AddAsync(mappedUser);
            CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);
           
         
            return createdUserDto;
        }
    }
}