﻿using Survey.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Services
{
    public interface IAdminService
    {
        Task AddAdminAsync(AdminAddDto newAdmin);
        Task<int> GetAdminFormToken(string token);
    }
}
