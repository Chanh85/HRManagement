using HRManagement.Application.Employee.Interfaces;
using HRManagement.Application.Employee.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            // Vì file này nằm cùng project, nó hoàn toàn nhìn thấy 'internal class EmployeeService'
            services.AddScoped<IEmployeeService, EmployeeServices>();
            return services;
        }
    }
}
