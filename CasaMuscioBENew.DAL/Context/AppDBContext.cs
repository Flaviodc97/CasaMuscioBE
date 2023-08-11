using CasaMuscioBENew.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaMuscioBENew.DAL.Context
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Roomate>? Roomate { get; set; }


    }
}
