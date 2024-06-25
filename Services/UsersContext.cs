namespace WeatherApp.RestApi.JwtAuthIdentity.Services;

public class UsersContext : IdentityUserContext<ApplicationUser>
{
    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=RnD;Integrated Security=SSPI;Connect Timeout=60;Application Name=RND-LOCAL;Trust Server Certificate=true;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}