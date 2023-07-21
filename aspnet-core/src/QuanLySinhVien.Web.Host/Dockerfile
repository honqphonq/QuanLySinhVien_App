FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/QuanLySinhVien.Web.Host/QuanLySinhVien.Web.Host.csproj", "src/QuanLySinhVien.Web.Host/"]
COPY ["src/QuanLySinhVien.Web.Core/QuanLySinhVien.Web.Core.csproj", "src/QuanLySinhVien.Web.Core/"]
COPY ["src/QuanLySinhVien.Application/QuanLySinhVien.Application.csproj", "src/QuanLySinhVien.Application/"]
COPY ["src/QuanLySinhVien.Core/QuanLySinhVien.Core.csproj", "src/QuanLySinhVien.Core/"]
COPY ["src/QuanLySinhVien.EntityFrameworkCore/QuanLySinhVien.EntityFrameworkCore.csproj", "src/QuanLySinhVien.EntityFrameworkCore/"]
WORKDIR "/src/src/QuanLySinhVien.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/QuanLySinhVien.Web.Host", "src/QuanLySinhVien.Web.Host"]
COPY ["src/QuanLySinhVien.Web.Core", "src/QuanLySinhVien.Web.Core"]
COPY ["src/QuanLySinhVien.Application", "src/QuanLySinhVien.Application"]
COPY ["src/QuanLySinhVien.Core", "src/QuanLySinhVien.Core"]
COPY ["src/QuanLySinhVien.EntityFrameworkCore", "src/QuanLySinhVien.EntityFrameworkCore"]
WORKDIR "/src/src/QuanLySinhVien.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "QuanLySinhVien.Web.Host.dll"]
