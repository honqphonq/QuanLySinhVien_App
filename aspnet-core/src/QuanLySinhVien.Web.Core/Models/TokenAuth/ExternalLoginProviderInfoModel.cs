using Abp.AutoMapper;
using QuanLySinhVien.Authentication.External;

namespace QuanLySinhVien.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
