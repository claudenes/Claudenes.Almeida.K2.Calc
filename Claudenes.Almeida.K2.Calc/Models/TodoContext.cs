using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Claudenes.Almeida.K2.Calc.Models;

namespace Claudenes.Almeida.K2.Calc.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Claudenes.Almeida.K2.Calc.Models.TaxaJuros> TaxaJuros { get; set; }

        public DbSet<Claudenes.Almeida.K2.Calc.Models.CalculaJuros> CalculaJuros { get; set; }
    }
}
