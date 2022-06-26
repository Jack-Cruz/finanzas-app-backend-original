﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using finanzas_backend_app.Data;

#nullable disable

namespace finanzas_backend_app.Migrations
{
    [DbContext(typeof(EasyFinanzasContext))]
    partial class EasyFinanzasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("finanzas_backend_app.Models.Bonista", b =>
                {
                    b.Property<int>("idbonista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DNI")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("RUC")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("celular")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("contrasenia")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("correo")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("direccion")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("distrito")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("provincia")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("region")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("usuario")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("idbonista");

                    b.ToTable("Bonistas");
                });

            modelBuilder.Entity("finanzas_backend_app.Models.Bono", b =>
                {
                    b.Property<int>("idbono")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("anios")
                        .HasColumnType("INTEGER");

                    b.Property<int>("capitalizacion")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("fecemision")
                        .HasColumnType("TEXT");

                    b.Property<int>("frecpago")
                        .HasColumnType("INTEGER");

                    b.Property<int>("idbonista")
                        .HasColumnType("INTEGER");

                    b.Property<double>("imprenta")
                        .HasColumnType("REAL");

                    b.Property<string>("moneda")
                        .HasColumnType("TEXT");

                    b.Property<double>("perccavali")
                        .HasColumnType("REAL");

                    b.Property<double>("perccolocacion")
                        .HasColumnType("REAL");

                    b.Property<double>("percestructuracion")
                        .HasColumnType("REAL");

                    b.Property<double>("percflotacion")
                        .HasColumnType("REAL");

                    b.Property<double>("percprima")
                        .HasColumnType("REAL");

                    b.Property<double>("tasadescuento")
                        .HasColumnType("REAL");

                    b.Property<double>("tasainteres")
                        .HasColumnType("REAL");

                    b.Property<string>("tipotasa")
                        .HasColumnType("TEXT");

                    b.Property<float>("valcomercial")
                        .HasColumnType("REAL");

                    b.Property<double>("valnominal")
                        .HasColumnType("REAL");

                    b.HasKey("idbono");

                    b.ToTable("Bonos");
                });

            modelBuilder.Entity("finanzas_backend_app.Models.BonoResumen", b =>
                {
                    b.Property<int>("idresumen")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("TCEAemisor")
                        .HasColumnType("REAL");

                    b.Property<double>("TCEAemisorescudo")
                        .HasColumnType("REAL");

                    b.Property<double>("TREAbonista")
                        .HasColumnType("REAL");

                    b.Property<double>("convexidad")
                        .HasColumnType("REAL");

                    b.Property<double>("duracion")
                        .HasColumnType("REAL");

                    b.Property<double>("duracionmod")
                        .HasColumnType("REAL");

                    b.Property<int>("idbono")
                        .HasColumnType("INTEGER");

                    b.Property<double>("precio")
                        .HasColumnType("REAL");

                    b.Property<double>("total")
                        .HasColumnType("REAL");

                    b.Property<double>("utilidad_perdida")
                        .HasColumnType("REAL");

                    b.HasKey("idresumen");

                    b.ToTable("BonoResumenes");
                });

            modelBuilder.Entity("finanzas_backend_app.Models.Flujo", b =>
                {
                    b.Property<int>("idflujo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("amortizacion")
                        .HasColumnType("REAL");

                    b.Property<double>("bono")
                        .HasColumnType("REAL");

                    b.Property<double>("convexidad")
                        .HasColumnType("REAL");

                    b.Property<double>("cuota")
                        .HasColumnType("REAL");

                    b.Property<double>("escudo")
                        .HasColumnType("REAL");

                    b.Property<double>("faplazo")
                        .HasColumnType("REAL");

                    b.Property<double>("flujoactual")
                        .HasColumnType("REAL");

                    b.Property<double>("flujobonista")
                        .HasColumnType("REAL");

                    b.Property<double>("flujoemisor")
                        .HasColumnType("REAL");

                    b.Property<double>("flujoemisorescudo")
                        .HasColumnType("REAL");

                    b.Property<int>("idbono")
                        .HasColumnType("INTEGER");

                    b.Property<double>("interes")
                        .HasColumnType("REAL");

                    b.Property<int>("n")
                        .HasColumnType("INTEGER");

                    b.Property<double>("prima")
                        .HasColumnType("REAL");

                    b.HasKey("idflujo");

                    b.ToTable("Flujos");
                });
#pragma warning restore 612, 618
        }
    }
}
