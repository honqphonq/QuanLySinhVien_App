using Abp.Application.Services.Dto;

namespace QuanLySinhVien.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

