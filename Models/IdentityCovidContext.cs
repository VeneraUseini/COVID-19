using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid_19.Models
{
    public class IdentityCovidContext : IdentityDbContext<Users>
    {
        public IdentityCovidContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PeopleWithCovid> PeopleWithCovids { get; set; }
    }
}
