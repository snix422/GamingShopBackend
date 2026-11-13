using AutoMapper;
using FootballShopBackend.Application.Common;
using FootballShopBackend.Application.Contracts.Infrastracture;
using MediatR;

namespace FootballShopBackend.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginUserDTO = _mapper.Map<LoginUserVM>(request);

            var result = await _authService.LoginAsync(loginUserDTO);

            return result;
        }
    }
}
