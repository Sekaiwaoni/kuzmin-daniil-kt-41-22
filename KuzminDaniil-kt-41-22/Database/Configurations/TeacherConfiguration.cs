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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "cd_teacher";
        
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            //primary key
            builder
                .HasKey(p => p.idTeacher)
                .HasName($"pk_{TableName}_id_Teacher");

            // Identity generation
            builder.Property(p => p.idTeacher).ValueGeneratedOnAdd();

            builder.Property(p => p.idTeacher)
                .HasColumnName("Teacher_id").HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.SurnameTeacher)
                .IsRequired()
                .HasColumnName("c_Teacher_surname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.NameTeacher)
                .IsRequired()
                .HasColumnName("c_Teacher_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.SecsurnameTeacher)
                .IsRequired()
                .HasColumnName("c_Teacher_secsurname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.idCafedra)
                .HasColumnName("Cafedra_id")
                .HasColumnType(ColumnType.Int).HasMaxLength(20)
                .HasComment("Идентификатор записи кафедры преподавателя");

            builder.ToTable(TableName)
                .HasOne(p => p.Cafedra)
                .WithMany()
                .HasForeignKey(p => p.idCafedra)
                .HasConstraintName("fk_f_groop_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.idCafedra, $"idx_{TableName}_fk_f_cafedra_id");

            builder.Navigation(p => p.Cafedra)
                .AutoInclude();
        }
    }
}