
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppUserDbContext;

public class WebAppUserDbContext : IdentityDbContext
{
    public WebAppUserDbContext(DbContextOptions<WebAppUserDbContext> options)
        : base(options)
    {

    }


}
