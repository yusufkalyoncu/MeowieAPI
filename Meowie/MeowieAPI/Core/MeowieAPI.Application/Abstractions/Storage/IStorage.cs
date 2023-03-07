using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MeowieAPI.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<(string userName, string fileName)> UploadAsync(string  userName, string pathOrContainerName, IFormFile file);

        Task DeleteAsync(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);




    }
}
