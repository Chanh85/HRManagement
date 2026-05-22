using HRManagement.Application.Common;
using HRManagement.Application.Employee.Interfaces;
using HRManagement.Infrastructure.Data;
using HRManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

            // Khởi tạo class internal một cách an toàn
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory(connectionString));
            return services;
        }
    }
}
