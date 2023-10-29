using Microsoft.EntityFrameworkCore;
using Student.Models;
using System.Collections.Generic;

namespace Student.Data
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(options) { }
        public DbSet<Register> Registers { get; set; }
        public DbSet<LoginDTO> LoginDTOs { get; set; }
    }
}
