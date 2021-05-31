using APITaxiPay.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaxiPay.Dados
{
    public class TaxiPayContexto : DbContext
    {
        public TaxiPayContexto(DbContextOptions<TaxiPayContexto> options) : base(options)
        {

        }

        public DbSet <Pessoa>Pessoas { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Cobrador> Cobradores { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Diaria> Diarias { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Corrida> Corridas { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Origem> Origens { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
