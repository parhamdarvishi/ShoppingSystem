using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingSystem.Identity.Application.Dtos.Authentication;
using ShoppingSystem.Identity.Application.Interfaces;
using ShoppingSystem.Identity.Application.Models.Jwt;
using ShoppingSystem.Identity.Domains.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingSystem.Identity.Infrastructure.Repositories;

public class JwtService : IJwtService
{
    private readonly UserManager<User> _userManager;
    private readonly JwtOption _jwtOption;

    public JwtService(UserManager<User> userManager, IOptions<JwtOption> jwtOption)
    {
        _userManager = userManager;
        _jwtOption = jwtOption.Value;
    }

    public async Task<LoginResponseDto> GenerateJwtTokenAsync(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Username);

        if (user is null)
            return null;

        if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            return null;

        //Token Payload 
        var tokenExpirationInMinute = DateTime.Now.AddMinutes(_jwtOption.ExpirationInMinute);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Id),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,user.UserName)
        }.Union(roleClaims);

        //Sign
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtOption.Issuer,
            audience: _jwtOption.Audience,
            claims: claims,
            expires: tokenExpirationInMinute,
            signingCredentials: signingCredentials);

        return new LoginResponseDto()
        {
            ExpireInMinute = (int)tokenExpirationInMinute.Subtract(DateTime.Now).TotalSeconds,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Username = user.UserName
        };
    }
}
