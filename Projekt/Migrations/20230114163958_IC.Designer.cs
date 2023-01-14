﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt.Models;

#nullable disable

namespace Projekt.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230114163958_IC")]
    partial class IC
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistEvent", b =>
                {
                    b.Property<int>("ArtistsArtistId")
                        .HasColumnType("int");

                    b.Property<int>("EventsEventId")
                        .HasColumnType("int");

                    b.HasKey("ArtistsArtistId", "EventsEventId");

                    b.HasIndex("EventsEventId");

                    b.ToTable("ArtistEvent");

                    b.HasData(
                        new
                        {
                            ArtistsArtistId = 1,
                            EventsEventId = 1
                        },
                        new
                        {
                            ArtistsArtistId = 2,
                            EventsEventId = 3
                        },
                        new
                        {
                            ArtistsArtistId = 3,
                            EventsEventId = 2
                        });
                });

            modelBuilder.Entity("Projekt.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Nickname");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Surname");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            Name = "Adam",
                            Nickname = "Szot",
                            Surname = "Kwieciński"
                        },
                        new
                        {
                            ArtistId = 2,
                            Name = "Paweł",
                            Nickname = "Pawełek",
                            Surname = "Jakubczyk"
                        },
                        new
                        {
                            ArtistId = 3,
                            Name = "Kamil",
                            Nickname = "Kamson",
                            Surname = "Kowalczyk"
                        });
                });

            modelBuilder.Entity("Projekt.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateTime>("DateOfEvent")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateOfEvent");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("EventDescription");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("EventName");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TicketPrice");

                    b.Property<string>("TypeOfEvent")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("EventType");

                    b.HasKey("EventId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            DateOfEvent = new DateTime(2023, 2, 1, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Całonocna zabawa z Szotem!",
                            Name = "Noc z Szotem!",
                            PlaceId = 3,
                            TicketPrice = 40m,
                            TypeOfEvent = "Koncert"
                        },
                        new
                        {
                            EventId = 2,
                            DateOfEvent = new DateTime(2023, 4, 12, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Spektakl teatralny ",
                            Name = "Romeo i Julia",
                            PlaceId = 1,
                            TicketPrice = 30m,
                            TypeOfEvent = "Teatr"
                        },
                        new
                        {
                            EventId = 3,
                            DateOfEvent = new DateTime(2023, 5, 14, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Opera",
                            Name = "Opera",
                            PlaceId = 2,
                            TicketPrice = 50m,
                            TypeOfEvent = "Opera"
                        });
                });

            modelBuilder.Entity("Projekt.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaceId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Address");

                    b.Property<string>("AddressNr")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("AddressNr");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("City");

                    b.Property<string>("PlaceDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("PlaceDescription");

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("PlaceName");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("PostalCode");

                    b.HasKey("PlaceId");

                    b.ToTable("Place");

                    b.HasData(
                        new
                        {
                            PlaceId = 1,
                            Address = "Młyńska",
                            AddressNr = "3",
                            City = "Kraków",
                            PlaceDescription = "abcd",
                            PlaceName = "Toro",
                            PostalCode = "00-000"
                        },
                        new
                        {
                            PlaceId = 2,
                            Address = "Szczecińska",
                            AddressNr = "4",
                            City = "Warszawa",
                            PlaceDescription = "abcd",
                            PlaceName = "Poro",
                            PostalCode = "58-402"
                        },
                        new
                        {
                            PlaceId = 3,
                            Address = "Powstańców",
                            AddressNr = "13",
                            City = "Katowice",
                            PlaceDescription = "abcd",
                            PlaceName = "Horo",
                            PostalCode = "21-370"
                        });
                });

            modelBuilder.Entity("Projekt.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TicketId");

                    b.HasIndex("EventId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            ClientId = "asad",
                            EventId = 1,
                            TicketPrice = 40m
                        },
                        new
                        {
                            TicketId = 2,
                            ClientId = "dasd",
                            EventId = 3,
                            TicketPrice = 50m
                        },
                        new
                        {
                            TicketId = 3,
                            ClientId = "dfsdfa",
                            EventId = 2,
                            TicketPrice = 30m
                        });
                });

            modelBuilder.Entity("ArtistEvent", b =>
                {
                    b.HasOne("Projekt.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt.Models.Event", b =>
                {
                    b.HasOne("Projekt.Models.Place", "Place")
                        .WithMany("Events")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Projekt.Models.Ticket", b =>
                {
                    b.HasOne("Projekt.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Projekt.Models.Place", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
