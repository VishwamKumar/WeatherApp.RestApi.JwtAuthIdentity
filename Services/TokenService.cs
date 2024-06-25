namespace WeatherApp.RestApi.JwtAuthIdentity.Services;

public class TokenService()
{
    public string CreateToken(ApplicationUser user, JwtSettings jwtSettings)
    {
        // Generate JWT token
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //Add Claims here
        var claims = CreateClaims(user);

        var newtoken = new JwtSecurityToken(
          issuer: jwtSettings.Issuer,
          audience: jwtSettings.Audience,
          claims: claims,
          expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryInMinutes),
          signingCredentials: credentials);

        return tokenHandler.WriteToken(newtoken);
    }


    private static List<Claim> CreateClaims(ApplicationUser user)
    {
        try
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "TokenForTheWeatherApp.RestApi.JwtAuthIdentity"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user?.UserName??"NA"),
                new Claim(ClaimTypes.Email, user?.Email??"NA"),
                new Claim("UserId", user.AppUserId.ToString())

            };
            return claims;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }  
}