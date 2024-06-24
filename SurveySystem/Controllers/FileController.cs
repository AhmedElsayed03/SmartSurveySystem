﻿using Microsoft.AspNetCore.Mvc;
using Survey.Application.Abstractions.Services.Storage;
using Survey.Application.Abstractions.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Survey.Application.Models.DTOs.Files;
using Survey.Infrastructure;

namespace SurveySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IStorageService _storageService;

        public FileController(IFileService fileService, IStorageService storageService)
        {
            _fileService = fileService;
            _storageService = storageService;
        }

        [HttpPost]
        public async Task<Ok<FileResultDto>> CreateFile(IFormFile file)
        {
            var fileInput = new FileInputDto(file.FileName.GetExtension(),
                file.FileName.GetFileNameWithoutExtension(),
                file.Length,
                file.OpenReadStream());
            var fileResult = await _fileService.CreateFileAsync(fileInput);
            return TypedResults.Ok(fileResult);
        }
    }
}