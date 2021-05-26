﻿// <auto-generated />
using System;
using ApiTaxiPay.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiTaxiPay.Migrations
{
    [DbContext(typeof(TaxiPayContexto))]
    [Migration("20210526095433_created_database")]
    partial class created_database
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiTaxiPay.Models.Carro", b =>
                {
                    b.Property<int>("CarroID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PessoaID")
                        .HasColumnType("int");

                    b.HasKey("CarroID");

                    b.HasIndex("PessoaID");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Carteira", b =>
                {
                    b.Property<int>("CarteiraID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaID")
                        .HasColumnType("int");

                    b.Property<string>("Saldo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarteiraID");

                    b.HasIndex("PessoaID")
                        .IsUnique();

                    b.ToTable("Carteiras");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Cobrador", b =>
                {
                    b.Property<int>("PessoaID")
                        .HasColumnType("int");

                    b.Property<string>("NumeroAssociado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PessoaID");

                    b.ToTable("Cobradores");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Corrida", b =>
                {
                    b.Property<int>("CorridaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiariaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RotaID")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("CorridaID");

                    b.HasIndex("DiariaID");

                    b.HasIndex("RotaID")
                        .IsUnique();

                    b.ToTable("Corridas");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Destino", b =>
                {
                    b.Property<int>("DestinoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinoID");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Diaria", b =>
                {
                    b.Property<int>("DiariaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Abertura")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarroID")
                        .HasColumnType("int");

                    b.Property<int?>("CobradorPessoaID")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecho")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MotoristaPessoaID")
                        .HasColumnType("int");

                    b.Property<int>("PessoaID")
                        .HasColumnType("int");

                    b.HasKey("DiariaID");

                    b.HasIndex("CarroID");

                    b.HasIndex("CobradorPessoaID");

                    b.HasIndex("MotoristaPessoaID");

                    b.ToTable("Diarias");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Motorista", b =>
                {
                    b.Property<int>("PessoaID")
                        .HasColumnType("int");

                    b.Property<string>("NumeroCarta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PessoaID");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Origem", b =>
                {
                    b.Property<int>("OrigemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrigemID");

                    b.ToTable("Origens");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Pagamento", b =>
                {
                    b.Property<int>("PagamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarteiraID")
                        .HasColumnType("int");

                    b.Property<int>("CorridaID")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tempo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("PagamentoID");

                    b.HasIndex("CarteiraID");

                    b.HasIndex("CorridaID");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Passageiro", b =>
                {
                    b.Property<int>("PessoaID")
                        .HasColumnType("int");

                    b.HasKey("PessoaID");

                    b.ToTable("Passageiros");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PessoaID");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Rota", b =>
                {
                    b.Property<int>("RotaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Custo")
                        .HasColumnType("float");

                    b.Property<int>("DestinoID")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrigemID")
                        .HasColumnType("int");

                    b.HasKey("RotaID");

                    b.HasIndex("DestinoID")
                        .IsUnique();

                    b.HasIndex("OrigemID")
                        .IsUnique();

                    b.ToTable("Rotas");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Carro", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Motorista", "Motorista")
                        .WithMany("Carros")
                        .HasForeignKey("PessoaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Carteira", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Passageiro", "Passageiro")
                        .WithOne("Carteira")
                        .HasForeignKey("ApiTaxiPay.Models.Carteira", "PessoaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Passageiro");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Cobrador", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Pessoa", "Pessoa")
                        .WithOne("Cobrador")
                        .HasForeignKey("ApiTaxiPay.Models.Cobrador", "PessoaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Corrida", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Diaria", "Diaria")
                        .WithMany("Corridas")
                        .HasForeignKey("DiariaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiTaxiPay.Models.Rota", "Rota")
                        .WithOne("Corrida")
                        .HasForeignKey("ApiTaxiPay.Models.Corrida", "RotaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Diaria");

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Diaria", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Carro", "Carro")
                        .WithMany("Diarias")
                        .HasForeignKey("CarroID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiTaxiPay.Models.Cobrador", "Cobrador")
                        .WithMany("Diarias")
                        .HasForeignKey("CobradorPessoaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ApiTaxiPay.Models.Motorista", "Motorista")
                        .WithMany("Diarias")
                        .HasForeignKey("MotoristaPessoaID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Carro");

                    b.Navigation("Cobrador");

                    b.Navigation("Motorista");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Motorista", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Pessoa", "Pessoa")
                        .WithOne("Motorista")
                        .HasForeignKey("ApiTaxiPay.Models.Motorista", "PessoaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Pagamento", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Carteira", "Carteira")
                        .WithMany("Pagamentos")
                        .HasForeignKey("CarteiraID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiTaxiPay.Models.Corrida", "Corrida")
                        .WithMany("Pagamentos")
                        .HasForeignKey("CorridaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carteira");

                    b.Navigation("Corrida");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Passageiro", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Pessoa", "Pessoa")
                        .WithOne("Passageiro")
                        .HasForeignKey("ApiTaxiPay.Models.Passageiro", "PessoaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Rota", b =>
                {
                    b.HasOne("ApiTaxiPay.Models.Destino", "Destino")
                        .WithOne("Rota")
                        .HasForeignKey("ApiTaxiPay.Models.Rota", "DestinoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApiTaxiPay.Models.Origem", "Origem")
                        .WithOne("Rota")
                        .HasForeignKey("ApiTaxiPay.Models.Rota", "OrigemID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Origem");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Carro", b =>
                {
                    b.Navigation("Diarias");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Carteira", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Cobrador", b =>
                {
                    b.Navigation("Diarias");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Corrida", b =>
                {
                    b.Navigation("Pagamentos");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Destino", b =>
                {
                    b.Navigation("Rota");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Diaria", b =>
                {
                    b.Navigation("Corridas");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Motorista", b =>
                {
                    b.Navigation("Carros");

                    b.Navigation("Diarias");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Origem", b =>
                {
                    b.Navigation("Rota");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Passageiro", b =>
                {
                    b.Navigation("Carteira");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Pessoa", b =>
                {
                    b.Navigation("Cobrador");

                    b.Navigation("Motorista");

                    b.Navigation("Passageiro");
                });

            modelBuilder.Entity("ApiTaxiPay.Models.Rota", b =>
                {
                    b.Navigation("Corrida");
                });
#pragma warning restore 612, 618
        }
    }
}
