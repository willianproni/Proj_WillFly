﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WillFly.Data;

namespace WillFly.Migrations
{
    [DbContext(typeof(WillFlyContext))]
    [Migration("20220403000457_CreateClass")]
    partial class CreateClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WillFly.Model.Aeronave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aeronave");
                });

            modelBuilder.Entity("WillFly.Model.Aeroporto", b =>
                {
                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sigla");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Aeroporto");
                });

            modelBuilder.Entity("WillFly.Model.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("WillFly.Model.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("WillFly.Model.Passageiro", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cpf");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Passageiro");
                });

            modelBuilder.Entity("WillFly.Model.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AeronaveId")
                        .HasColumnType("int");

                    b.Property<string>("DestinoSigla")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("HorarioDesembarque")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HorarioEmbarque")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrigemSigla")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PassageiroCpf")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AeronaveId");

                    b.HasIndex("DestinoSigla");

                    b.HasIndex("OrigemSigla");

                    b.HasIndex("PassageiroCpf");

                    b.ToTable("Voo");
                });

            modelBuilder.Entity("WillFly.Model.Aeroporto", b =>
                {
                    b.HasOne("WillFly.Model.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("WillFly.Model.Passageiro", b =>
                {
                    b.HasOne("WillFly.Model.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("WillFly.Model.Voo", b =>
                {
                    b.HasOne("WillFly.Model.Aeronave", "Aeronave")
                        .WithMany()
                        .HasForeignKey("AeronaveId");

                    b.HasOne("WillFly.Model.Aeroporto", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoSigla");

                    b.HasOne("WillFly.Model.Aeroporto", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemSigla");

                    b.HasOne("WillFly.Model.Passageiro", "Passageiro")
                        .WithMany()
                        .HasForeignKey("PassageiroCpf");

                    b.Navigation("Aeronave");

                    b.Navigation("Destino");

                    b.Navigation("Origem");

                    b.Navigation("Passageiro");
                });
#pragma warning restore 612, 618
        }
    }
}
