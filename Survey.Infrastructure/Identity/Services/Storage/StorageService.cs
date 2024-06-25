using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Survey.Application.Abstractions.Services.Storage;
using Survey.Application.Models.DTOs.Files;
using static Survey.Infrastructure.InfrastractureConstants.AppSettings;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public StorageService(IConfiguration configuration,
            IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public async Task<string> UploadFileAsync(Stream file, string fileName)
        {
            await SaveFileToFolder(file, fileName);
            string url = GetFileUrl(fileName);
            return url;
        }

        private async Task SaveFileToFolder(Stream file, string fileName)
        {
            var folderPath = _configuration.GetValue<string>(StoragePath)!;
            string filePath = Path.Combine(folderPath, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }

        private string GetFileUrl(string fileName)
        {
            var httpRequest = _contextAccessor.HttpContext!.Request;
            var builder = new UriBuilder()
            {
                Scheme = httpRequest.Scheme,
                Host = httpRequest.Host.Host,
                Port = httpRequest.Host.Port ?? default,
                Path = Path.Combine(FileConfigurations.StaticPath, fileName),
            };
     
            var url = builder.ToString();
            return url;
        }
    }
}
