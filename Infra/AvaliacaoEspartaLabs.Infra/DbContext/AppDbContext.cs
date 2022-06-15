using AvaliacaoEspartaLabs.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Oficina> Oficinas { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<CargaTrabalho> CargasTrabalho { get; set; }

    }
}
