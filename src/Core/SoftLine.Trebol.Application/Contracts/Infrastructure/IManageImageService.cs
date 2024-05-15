using SoftLine.Trebol.Application.Models.ImageManagement;

namespace SoftLine.Trebol.Application.Contracts.Infrastructure;

public interface IManageImageService
{
    Task<ImageResponse> UploadImage(ImageData imageStream);
}