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
            optionsBuilder.UseMySQL("Server=217.25.89.68;database=scp682;user=sDether;password=1namQfeg1_;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Point> Coordinates { get; set; }
        public DbSet<SafeZone> SafeZones { get; set; }
    }
}
