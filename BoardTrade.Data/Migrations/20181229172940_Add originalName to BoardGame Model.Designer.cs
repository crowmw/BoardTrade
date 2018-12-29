﻿// <auto-generated />
using System;
using BoardTrade.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoardTrade.Data.Migrations
{
    [DbContext(typeof(BoardTradeDbContext))]
    [Migration("20181229172940_Add originalName to BoardGame Model")]
    partial class AddoriginalNametoBoardGameModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoardTrade.Data.Models.BoardGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AverageRating");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsExpansion");

                    b.Property<int>("MaxPlayers");

                    b.Property<int>("MinPlayers");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("OriginalName");

                    b.Property<int>("PlayingTime");

                    b.Property<int>("Rank");

                    b.Property<float>("Rating");

                    b.Property<string>("Slug")
                        .IsRequired();

                    b.Property<string>("ThumbnailUrl");

                    b.Property<DateTime>("TimeOfCreation");

                    b.Property<DateTime>("TimeOfModification");

                    b.Property<int>("YearPublished");

                    b.HasKey("Id");

                    b.ToTable("BoardGames");
                });

            modelBuilder.Entity("BoardTrade.Data.Models.UserBoardGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BoardGameId");

                    b.Property<int>("Condition");

                    b.Property<bool>("ForExchange");

                    b.Property<bool>("ForSale");

                    b.Property<string>("Language");

                    b.Property<string>("Note");

                    b.Property<float>("Price");

                    b.Property<bool>("Shipping");

                    b.Property<float>("ShippingPrice");

                    b.Property<DateTime>("TimeOfCreation");

                    b.Property<DateTime>("TimeOfModification");

                    b.Property<bool>("Unwanted");

                    b.Property<bool>("Wanted");

                    b.HasKey("Id");

                    b.HasIndex("BoardGameId");

                    b.ToTable("UsersBoardGames");
                });

            modelBuilder.Entity("BoardTrade.Data.Models.UserBoardGame", b =>
                {
                    b.HasOne("BoardTrade.Data.Models.BoardGame", "BoardGame")
                        .WithMany()
                        .HasForeignKey("BoardGameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
