using MyFinances.Core.Aggregates;
using MyFinances.Infra.Dtos;

namespace MyFinances.Infra.Services
{
    public interface ITokenService
    {
        TokenDto GenerateToken(User user);
    }
}
