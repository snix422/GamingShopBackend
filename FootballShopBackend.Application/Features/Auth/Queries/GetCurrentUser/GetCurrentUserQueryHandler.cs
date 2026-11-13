using AutoMapper;
using FootballShopBackend.Application.Contracts.Infrastracture;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Auth.Queries.GetCurrentUser
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetCurrentUserQueryHandler(IMapper mapper, IUserRepository userRepository, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }

        public async Task<UserDTO> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;

            if(userId == null)
            {
                throw new Exception("Użytnik nie jest zalogowany");
            }

            var userEntity = await _userRepository.GetByIdAsync(userId, cancellationToken);

            if (userEntity == null)
            {
                throw new Exception("Użytkownik nie istnieje");
            }

            var userDTO = _mapper.Map<UserDTO>(userEntity);

            return userDTO;
        }
    }
}
