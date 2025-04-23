using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql.EntityFrameworkCore;
using KuzminDaniil_kt_41_22.Database;
using KuzminDaniil_kt_41_22.Database.Helper;
using KuzminDaniil_kt_41_22;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuzminDaniil_kt_41_22.Database
{
    public class CafedraConfiguration : IEntityTypeConfiguration<Cafedra>
    {
        private const string TableName = "cd_teacher";
        
        public void Configure(EntityTypeBuilder<Cafedra> builder)
        {
            //primary key
            builder
                .HasKey(p => p.idCafedra)
                .HasName($"pk_{TableName}_id_Cafedra");

            // Identity generation
            builder.Property(p => p.idCafedra).ValueGeneratedOnAdd();

            builder.Property(p => p.idCafedra)
                .HasColumnName("Cafedra_id").HasComment("Идентификатор записи кафедры");

            builder.Property(p => p.ZavCafName)
                .IsRequired()
                .HasColumnName("c_ZavCafedra_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("ФИО Заведующего кафедрой");

            builder.Property(p => p.NameCafedra)
                .IsRequired()
                .HasColumnName("c_Cafedra_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название кафедры");

            builder.Property(p => p.isZavCaf)
                .IsRequired()
                .HasColumnName("c_Cafedra_Заведующий?")
                .HasColumnType(ColumnType.Bool).HasMaxLength(100)
                .HasComment("Являеться ли заведующим");

            builder.Property(p => p.idZavCaf)
                .HasColumnName("idZavCaf")
                .HasColumnType(ColumnType.Int).HasMaxLength(20)
                .HasComment("Идентификатор записи заведующего кафедры ");
            //
            builder.Property(p => p.FoudationDate)
                .HasColumnName("FoundationDate")
                .HasColumnType(ColumnType.Date).HasMaxLength(20)
                .HasComment("Дата основания");
            builder.ToTable(TableName)
                .HasMany("Zavcaf")
                .WithOne()
                .HasForeignKey("idZavCaf")
                .HasConstraintName("fk_f_teacher_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.idZavCaf, $"idx_{TableName}_fk_f_teacher_id");

            builder.Navigation(p => p.ZavCaf)
                .AutoInclude();
        }
    }
}