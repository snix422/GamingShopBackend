using AutoMapper;
using FootballShopBackend.Application.Common;
using FootballShopBackend.Application.Contracts.Infrastracture;
using MediatR;
using System.Runtime.InteropServices;

namespace FootballShopBackend.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<string>>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerUserDTO = _mapper.Map<RegisterUserVM>(request);

            var result = await _authService.RegisterAsync(registerUserDTO);

            return result;
        }
    }
}
