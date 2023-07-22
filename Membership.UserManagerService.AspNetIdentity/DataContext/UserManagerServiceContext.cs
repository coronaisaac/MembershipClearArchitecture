namespace Membership.UserManagerService.AspNetIdentity.DataContext
{
    internal class UserManagerServiceContext : IdentityDbContext<User>
    {
        readonly AspNetIdentityOptions options;

        public UserManagerServiceContext(IOptions<AspNetIdentityOptions> options)
        {
            this.options = options.Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(options.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
