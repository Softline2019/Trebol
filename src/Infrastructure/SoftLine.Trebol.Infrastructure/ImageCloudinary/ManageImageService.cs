using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using SoftLine.Trebol.Application.Models.ImageManagement;
using SoftLine.Trebol.Application.Contracts.Infrastructure;

namespace SoftLine.Trebol.Infrastructure.ImageCloudinary;

public class ManageImageService : IManageImageService
{
    public CloudinarySettings _cloudinarySettings { get; }

    public ManageImageService(IOptions<CloudinarySettings> cloudinarySettings)
    {
        _cloudinarySettings = cloudinarySettings.Value;
    }

    public async Task<ImageResponse> UploadImage(ImageData imageStream)
    {
        var account = new Account(_cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret);

        var cloudinary = new Cloudinary(account);

        var uploadImage = new ImageUploadParams()
        {
            File = new FileDescription(imageStream.Name, imageStream.ImageStream)
        };

        var uploadResult = await cloudinary.UploadAsync(uploadImage);

        if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return new ImageResponse
            {
                PublicId = uploadImage.PublicId,
                Url = uploadResult.Url.ToString()
            };
        }

        throw new Exception("No se pudo guardar la imagen");
    }
}