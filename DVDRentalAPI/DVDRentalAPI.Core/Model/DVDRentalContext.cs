using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DVDRentalAPI.Core.Model
{
    public partial class DVDRentalContext : DbContext
    {
        public DVDRentalContext()
        {
        }

        public DVDRentalContext(DbContextOptions<DVDRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieActor> MovieActor { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<RentalHistory> RentalHistory { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Writer> Writer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=OdeToCodeDB;User Id=sa;Password=<YourStrong@Passw0rd>;Trusted_Connection=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.Property(e => e.LastUpdatedBy).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.City)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Address__City_Id__49C3F6B7");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.LastUpdatedBy).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__City__State_Id__2A164134");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.LastUpdatedBy).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasOne(d => d.LivingCountry)
                    .WithMany(p => p.Director)
                    .HasForeignKey(d => d.LivingCountryId)
                    .HasConstraintName("FK__Director__Living__5CD6CB2B");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.LastUpdatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Genre)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Genre__Movie_Id__6EF57B66");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.LastUpdatedBy).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Inventory__Movie__03F0984C");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Inventory__Store__04E4BC85");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.LastUpdatedBy).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Language)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Language__Movie___00200768");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.Property(e => e.MediaUrl).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Media__Movie_Id__208CD6FA");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK__Movie__Director___656C112C");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.ProductionId)
                    .HasConstraintName("FK__Movie__Productio__66603565");

                entity.HasOne(d => d.Writer)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.WriterId)
                    .HasConstraintName("FK__Movie__Writer_Id__6754599E");
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => e.MaId)
                    .HasName("PK__MovieAct__53E13245041099E8");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__MovieActo__Actor__1CBC4616");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__MovieActo__Movie__1DB06A4F");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => e.ProductionId)
                    .HasName("PK__Producer__6FE4D58FBA9640E3");

                entity.HasOne(d => d.HqCountry)
                    .WithMany(p => p.Producer)
                    .HasForeignKey(d => d.HqCountryId)
                    .HasConstraintName("FK__Producer__HQ_Cou__5FB337D6");
            });

            modelBuilder.Entity<RentalHistory>(entity =>
            {
                entity.HasKey(e => e.RentalId)
                    .HasName("PK__RentalHi__9D23A46613299E90");

                entity.Property(e => e.LastUpdatedBy).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.RentalHistory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RentalHis__Store__08B54D69");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RentalHistory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RentalHis__User___09A971A2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.LastUpdatedBy).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__State__Country_I__29221CFB");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Store__Address_I__7B5B524B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Store__User_Id__7C4F7684");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__206D9170305C2D91");

                entity.Property(e => e.LastUpdatedBy).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Users__Address_I__778AC167");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__Role_Id__787EE5A0");
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.HasOne(d => d.LivingCountry)
                    .WithMany(p => p.Writer)
                    .HasForeignKey(d => d.LivingCountryId)
                    .HasConstraintName("FK__Writer__Living_C__628FA481");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
