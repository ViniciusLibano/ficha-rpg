using RpgApi.Domain.Entities;

namespace RpgApi.Application.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}