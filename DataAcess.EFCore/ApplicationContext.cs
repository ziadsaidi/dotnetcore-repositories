using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.EFCore
{
    public class ApplicationContext:DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options ):base(options){

        }
       public DbSet<Developer> Developers { get; set; }
       public DbSet<Project> Projects { get; set; }
    }
}