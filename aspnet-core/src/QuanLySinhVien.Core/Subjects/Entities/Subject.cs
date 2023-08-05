using Abp.Domain.Entities;
using System;

namespace QuanLySinhVien.Subjects.Entities;

public class Subject : Entity<Guid>
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public static Subject Create(string name, string? description)
    {
        return new Subject
        {
            Name = name,
            Description = description
        };
    }
}
