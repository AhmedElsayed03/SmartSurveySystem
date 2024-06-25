using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Survey.Application.Abstractions.Services;
using Survey.Application.Abstractions.Services.Storage;
using Survey.Application.Abstractions.UnitOfWork;
using Survey.Application.Execptions;
using Survey.Application.Models.DTOs.Files;
using Survey.Domain.Entities;
using Survey.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Services
{
    public class FileService : IFileService
    {
        private readonly FileConfigurations _fileConfiguration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;


        public FileService(IOptions<FileConfigurations> fileOptions,
            IUnitOfWork unitOfWork,
            IStorageService storageService)
        {
            _fileConfiguration = fileOptions.Value;
            _unitOfWork = unitOfWork;
            _storageService = storageService;

        }

        #region Create Files

        public async Task<FileResultDto> CreateFileAsync(FileInputDto fileDto)
        { 

            var fileType = GetFileType(fileDto.Extention);
            var savedFileName = Guid.NewGuid().ToString() + fileDto.Extention;
            var url = await _storageService.UploadFileAsync(fileDto.Stream!, savedFileName);

            var uploadedFile = new UploadedFile
            {
                Name = fileDto.Name,
                Size = fileDto.Length,
                FileType = fileType,
                Url = url,
                MemberId = fileDto.MemberId,

            };
            await _unitOfWork.UploadedFileRepo.AddAsync(uploadedFile);
            await _unitOfWork.SaveChangesAsync();

            return new FileResultDto(uploadedFile.Id, url);
        }

        private FileType GetFileType(string extension)
        {
            return extension switch
            {
                _ when _fileConfiguration.WordExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase) => FileType.Word,
                _ when _fileConfiguration.PdfExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase) => FileType.Pdf,
                _ when _fileConfiguration.ImageExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase) => FileType.Image,
                _ when _fileConfiguration.VideoExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase) => FileType.Video,
                _ => default
            };
        }

        #endregion

    }
}
