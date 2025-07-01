using Microsoft.AspNetCore.Http;

namespace school_Project.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImageAsync(string Location, IFormFile file);
    }
}
