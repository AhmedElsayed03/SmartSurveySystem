﻿using Survey.Application.Models.DTOs;
using Survey.Application.Models.DTOs.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<FileResultDto> CreateFileAsync(FileInputDto fileDto);
        Task<FileReadDto> GetFileAsync(int id);
    }
}
