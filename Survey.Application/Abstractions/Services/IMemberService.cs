using Survey.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Services
{
    public interface IMemberService
    {
        Task AddMemberAsync(MemberAddDto newMember);
    }
}
