using System;
using Autodealers.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServerUtilities;

namespace Autodealers.Models
{
    public partial class AutodealersContext : DbContext
    {
        public AutodealersContext()
        {
            Database.EnsureCreated();
        }

        public AutodealersContext(DbContextOptions<AutodealersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autodealer> Autodealer { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<Statistics> Statistics { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Userautodealer> Userautodealer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=autodealers;user=root;pwd=mysqlpassword", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var bodyColorConverter = new ValueConverter<BodyColor, string>(
                v => Utilities.GetDescription(v),
                v => Utilities.GetValueByDescription<BodyColor>(v));

            var bodyTypeConverter = new ValueConverter<BodyType, string>(
                v => Utilities.GetDescription(v),
                v => Utilities.GetValueByDescription<BodyType>(v));

            var engineTypeConverter = new ValueConverter<EngineType, string>(
                v => Utilities.GetDescription(v),
                v => Utilities.GetValueByDescription<EngineType>(v));

            var interiorColorConverter = new ValueConverter<InteriorColor, string>(
                v => Utilities.GetDescription(v),
                v => Utilities.GetValueByDescription<InteriorColor>(v));

            var interiorMaterialConverter = new ValueConverter<InteriorMaterial, string>(
                v => Utilities.GetDescription(v),
                v => Utilities.GetValueByDescription<InteriorMaterial>(v));

            var transmissionTypeConverter = new ValueConverter<TransmissionType, string>(
                v => Utilities.GetDescription(v),
                v => Utilities.GetValueByDescription<TransmissionType>(v));

            var wheelDriveTypeConverter = new ValueConverter<WheelDriveType, string>(
                v => Utilities.GetDescription(v),
                v => Utilities.GetValueByDescription<WheelDriveType>(v));

            var monthConverter = new ValueConverter<Month, string>(
                v => Utilities.GetDescription(v),
                v => Utilities.GetValueByDescription<Month>(v));

            var passwordDecrypter = new ValueConverter<string, string>(
                v => EncryptPassword(v),
                v => DecryptPassword(v));


            modelBuilder.Entity<Autodealer>(entity =>
            {
                entity.ToTable("autodealer");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WorkingHours)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.HasIndex(e => e.AutodealerId)
                    .HasName("AutodealerId_idx");

                entity.Property(e => e.BodyColor)
                    .IsRequired()
                    .HasColumnType("enum('Белый','Бордовый','Желтый','Зеленый','Коричневый','Красный','Оранжевый','Серебристый','Серый','Синий','Фиолетовый','Черный','Другой')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(bodyColorConverter);
                

                entity.Property(e => e.BodyType)
                    .IsRequired()
                    .HasColumnType("enum('Внедорожник 3 дв.', 'Внедорожник 5 дв.', 'Кабриолет', 'Купе', 'Легковой фургон', 'Лимузин', 'Лифтбек', 'Микроавтобус грузопассажирский', 'Микроавтобус пассажирский', 'Минивен', 'Пикап', 'Родстер', 'Седан', 'Универсал', 'Хэтчбек 3 дв.', 'Хэтчбек 5 дв.', 'Другой')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(bodyTypeConverter);

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EngineType)
                    .IsRequired()
                    .HasColumnType("enum('Бензиновый', 'Дизельный', 'Электро')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(engineTypeConverter);

                entity.Property(e => e.InteriorColor)
                    .IsRequired()
                    .HasColumnType("enum('Светлый', 'Темный', 'Комбинированный')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(interiorColorConverter);

                entity.Property(e => e.InteriorMaterial)
                    .IsRequired()
                    .HasColumnType("enum('Натуральная кожа', 'Искусственная кожа', 'Ткань', 'Велюр', 'Алькантара', 'Комбинированный')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(interiorMaterialConverter);

                entity.Property(e => e.Mileage).HasColumnType("decimal(10,0)");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price).HasColumnType("decimal(10,0)");

                entity.Property(e => e.AllowanceOrDiscount).HasColumnType("decimal(10,0)");

                entity.Property(e => e.TransmissionType)
                    .IsRequired()
                    .HasColumnType("enum('Автоматическая', 'Механическая')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(transmissionTypeConverter);

                entity.Property(e => e.WheelDriveType)
                    .IsRequired()
                    .HasColumnType("enum('Передний', 'Задний', 'Подключаемый полный', 'Постоянный полный')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(wheelDriveTypeConverter);

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Autodealer)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.AutodealerId)
                    .HasConstraintName("AutodealerId");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.ToTable("deal");

                entity.HasIndex(e => e.CarId)
                    .HasName("fk_Deal_Car1_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId_idx");

                entity.Property(e => e.Amount).HasColumnType("decimal(10,0)");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Deal)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("CarId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Deal)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserId_FK2");
            });

            modelBuilder.Entity<Statistics>(entity =>
            {
                entity.ToTable("statistics");

                entity.HasIndex(e => e.AutodealerId)
                    .HasName("AutodealerId_idx");

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasColumnType("enum('Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(monthConverter);

                entity.Property(e => e.Profit).HasColumnType("decimal(10,0)");

                entity.Property(e => e.TotalSales).HasColumnType("decimal(10,0)");

                entity.Property(e => e.ExpectedProfit).HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.Autodealer)
                    .WithMany(p => p.Statistics)
                    .HasForeignKey(d => d.AutodealerId)
                    .HasConstraintName("AutodealerId_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Firstname)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci")
                    .HasConversion(passwordDecrypter);

                entity.Property(e => e.Surname)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Telephone)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DateOfRegistration)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Userautodealer>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AutodealerId })
                    .HasName("PRIMARY");

                entity.ToTable("userautodealer");

                entity.HasIndex(e => e.AutodealerId)
                    .HasName("AutodealerId_idx");

                entity.HasOne(d => d.Autodealer)
                    .WithMany(p => p.Userautodealer)
                    .HasForeignKey(d => d.AutodealerId)
                    .HasConstraintName("AutodealerId_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userautodealer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private string DecryptPassword(string password)
        {
            string decryptedPassword = string.Empty;

            foreach (var c in password)
            {
                decryptedPassword += Convert.ToChar((int)c - 1);
            }

            return decryptedPassword;
        }

        private string EncryptPassword(string password)
        {
            string encryptedPassword = string.Empty;

            foreach (var c in password)
            {
                encryptedPassword += Convert.ToChar((int)c + 1);
            }

            return encryptedPassword;
        }
    }
}
