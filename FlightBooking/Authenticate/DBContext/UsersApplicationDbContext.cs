using Authenticate.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate.DBContext
{
    public class UsersApplicationDbContext: DbContext
    {
        public UsersApplicationDbContext(DbContextOptions<UsersApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Users> tblUserRegistor { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }

}
}
