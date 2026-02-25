using Microsoft.AspNetCore.Components.Forms;

namespace File_Upload.Services
{

    public interface IFileUpload
    {
        Task UploadFile(IBrowserFile file);
        Task<string> GeneratePreviewUrl(IBrowserFile file); 
    }

    public class FileUpload : IFileUpload
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileUpload> _logger;
        
        public FileUpload(IWebHostEnvironment webHostEnvironment, ILogger<FileUpload> logger)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;   
        }

        public async Task UploadFile(IBrowserFile file)
        {
            if (file is not null)
            {
                try
                {
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", file.Name);

                    using (var stream = file.OpenReadStream())
                    using (var fileStream = File.Create(uploadPath))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }
        }

        public async Task<string> GeneratePreviewUrl(IBrowserFile file)
        {
            if (!file.ContentType.Contains("image")) 
            {
                if (file.ContentType.Contains("pdf"))
                {
                    return "images/pdf_logo.png";
                }
            }
            
            // Resize image to 100 x 100 Pixel
            var resizedImage = await file.RequestImageFileAsync(file.ContentType, 100, 100);
            // Reserve storage for file 
            var buffer = new byte[resizedImage.Size];
            // load file to storage
            await resizedImage.OpenReadStream().ReadAsync(buffer);  
            // transform date to binary string
            return $"data: {file.ContentType};base64, {Convert.ToBase64String(buffer)}";
        }
    }
}
