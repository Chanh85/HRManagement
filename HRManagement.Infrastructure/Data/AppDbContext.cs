using HRManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrganizationUnit> Organizations { get; set; }
        public DbSet<Position> Positions { get; set; }

        // Cấu hình Fluent API để quản lý các mối quan hệ (Relationships)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình Employee -> Organization (Không cho phép xoá Phòng ban nếu còn Nhân viên)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OrganizationUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Dùng Restrict để chặn lỗi Cascade

            // Cấu hình Employee -> Position (Không cho phép xoá Chức vụ nếu đang có người làm)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình Position -> Organization (Xoá Phòng ban thì xoá luôn các Chức vụ thuộc phòng đó)
            modelBuilder.Entity<Position>()
                .HasOne(p => p.Organization)
                .WithMany(o => o.Positions)
                .HasForeignKey(p => p.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
