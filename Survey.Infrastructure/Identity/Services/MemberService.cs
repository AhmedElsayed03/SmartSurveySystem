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
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddMemberAsync(MemberAddDto newMember)
        {
            Member member = new Member {
                Age = newMember.Age,
                Location = newMember.Location,
                UserId = newMember.UserId,
            };
            await _unitOfWork.MemberRepo.AddAsync(member);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
