using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Subjects.Consts;
using QuanLySinhVien.Subjects.Entities;

namespace QuanLySinhVien.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable(nameof(Subject));

        builder.Property(x => x.Name)
            .HasMaxLength(SubjectConsts.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(SubjectConsts.DescriptionMaxLength);
    }
}
