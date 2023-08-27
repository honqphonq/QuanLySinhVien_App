using System;

namespace QuanLySinhVien.Subjects.Dtos;

public record SubjectGetResponse(
    Guid Id,
    string Name,
    string Description);
