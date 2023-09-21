﻿using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using LaBook_Planet.Library.Core.Services.Interfaces.External;

namespace LaBook_Planet.Library.Core.Services.Implementations
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;
        public ImageService(IConfiguration config)
        {
            var cloudName = config.GetSection("CloudinarySettings:CloudName").Value;
            var apiKey = config.GetSection("CloudinarySettings:ApiKey").Value;
            var apiSecret = config.GetSection("CloudinarySettings:ApiSecret").Value;



            Account account = new Account
            {
                ApiKey = apiKey,
                ApiSecret = apiSecret,
                Cloud = cloudName
            };



            cloudinary = new Cloudinary(account);
        }
        public async Task<Dictionary<string, string>> UploadImage(IFormFile image, string folderName)
        {
            var file = image;



            var response = new Dictionary<string, string>();
            var defaultSize = 300000;
            var allowedTypes = new List<string>() { "jpeg", "jpg", "png" };
            var uploadResult = new ImageUploadResult();



            if (file.Length < 1 || file.Length > defaultSize)
            {
                response.Add("Code", "400");
                response.Add("Message", "Invalid size");
                return response;
            }



            foreach (var item in allowedTypes)
            {
                if (allowedTypes.Contains(file.ContentType))
                {
                    response.Add("Code", "400");
                    response.Add("Message", "Invalid type");
                    return response;
                }
            }



            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    //Transformation = new Transformation().Width(272).Height(500).Crop("fill").Gravity("face"),
                    Folder = folderName
                };
                uploadResult = await cloudinary.UploadAsync(uploadParams);
            }



            if (!string.IsNullOrEmpty(uploadResult.PublicId))
            {
                response.Add("Code", "200");
                response.Add("Message", "upload successful");
                response.Add("PublicId", uploadResult.PublicId);
                response.Add("Url", uploadResult.Url.ToString());



                return response;
            }



            response.Add("Code", "400");
            response.Add("Message", "Failed to upload");
            return response;
        }
    }
}
