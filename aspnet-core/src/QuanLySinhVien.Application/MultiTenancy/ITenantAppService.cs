using Abp.Application.Services;
using QuanLySinhVien.MultiTenancy.Dto;

namespace QuanLySinhVien.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

