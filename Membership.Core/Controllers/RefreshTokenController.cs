using Membership.Shared.Dtos;

namespace Membership.Core.Controllers;
internal class RefreshTokenController : IRefreshTokenController
{
    readonly IRefreshTokenInputPort InputPort;
    readonly IRefreshTokenOutput OutputPort;

    public RefreshTokenController(IRefreshTokenInputPort inputPort,
        IRefreshTokenOutput outputPort)
    {
        InputPort = inputPort;
        OutputPort = outputPort;
    }

    public async Task<UserTokenDto> RefreshTokenAsync(UserTokenDto userTokens)
    {
        await InputPort.RefreshTokenAsync(userTokens);
        return OutputPort.UserTokenDto;
    }
}