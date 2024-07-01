namespace WeatherApp.RestApi.JwtAuthIdentity.Services;

public class ApplicationUser : IdentityUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AppUserId { get; set; }
}
