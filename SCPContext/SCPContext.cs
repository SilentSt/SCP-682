using Microsoft.EntityFrameworkCore;

using MySql.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPData
{
    public class SCPContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;database=name;user=root;password=12345678;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Point> Coordinates { get; set; }
        public DbSet<SafeZone> SafeZones { get; set; }
    }
}
