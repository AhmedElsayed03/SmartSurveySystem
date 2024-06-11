using Survey.Application.Abstractions.Services;
using Survey.Application.Abstractions.UnitOfWork;
using Survey.Application.Models.DTOs;
using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAdminAsync(AdminAddDto newAdmin)
        {
            Admin admin = new Admin
            {
                JobTitle = newAdmin.JobTitle,
                Department = newAdmin.Department,
                UserId = newAdmin.UserId,
            };
            await _unitOfWork.AdminRepo.AddAsync(admin);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
