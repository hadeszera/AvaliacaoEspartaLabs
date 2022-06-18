﻿// <auto-generated />
using System;
using AvaliacaoEspartaLabs.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvaliacaoEspartaLabs.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220618001825_add-CargaTrabalhoMaxima")]
    partial class addCargaTrabalhoMaxima
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AvaliacaoEspartaLabs.Domain.Entities.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CargaTrabalhoAtual")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataServico")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdOficina")
                        .HasColumnType("int");

                    b.Property<int?>("OficinaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OficinaId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("AvaliacaoEspartaLabs.Domain.Entities.CargaTrabalho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AgendaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgenda")
                        .HasColumnType("int");

                    b.Property<int>("Servico")
                        .HasColumnType("int");

                    b.Property<int>("UnidadeTrabalho")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("CargasTrabalho");
                });

            modelBuilder.Entity("AvaliacaoEspartaLabs.Domain.Entities.Oficina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CargaTrabalhoMaxima")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Oficinas");
                });

            modelBuilder.Entity("AvaliacaoEspartaLabs.Domain.Entities.Agenda", b =>
                {
                    b.HasOne("AvaliacaoEspartaLabs.Domain.Entities.Oficina", "Oficina")
                        .WithMany("Agendas")
                        .HasForeignKey("OficinaId");

                    b.Navigation("Oficina");
                });

            modelBuilder.Entity("AvaliacaoEspartaLabs.Domain.Entities.CargaTrabalho", b =>
                {
                    b.HasOne("AvaliacaoEspartaLabs.Domain.Entities.Agenda", "Agenda")
                        .WithMany("CargasTrabalho")
                        .HasForeignKey("AgendaId");

                    b.Navigation("Agenda");
                });

            modelBuilder.Entity("AvaliacaoEspartaLabs.Domain.Entities.Agenda", b =>
                {
                    b.Navigation("CargasTrabalho");
                });

            modelBuilder.Entity("AvaliacaoEspartaLabs.Domain.Entities.Oficina", b =>
                {
                    b.Navigation("Agendas");
                });
#pragma warning restore 612, 618
        }
    }
}
