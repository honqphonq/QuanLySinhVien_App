using AutoMapper;
using QuanLySinhVien.Authorization.Users;
using QuanLySinhVien.Users.Dto;
using System.Linq;

namespace QuanLySinhVien.Users.Mapping;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<User, UserDto>()
          .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.Name))
          .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.Surname))
          .ForMember(d => d.Email, opt => opt.MapFrom(s => s.EmailAddress))
          .ForMember(d => d.RoleId, opt => opt.MapFrom(s => s.Roles.Select(r => r.RoleId).First()));
    }
}
