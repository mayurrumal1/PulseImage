using Microsoft.AspNetCore.Http;
using PulseImageProject.Data.Models;
using PulseImageProject.Data.Repos.Contracts;
using System.IO;

namespace PulseImageProject.Logic
{
	public class ImageLogic : Contracts.IImageLogic
	{
		private readonly IImageRepository _imageRepo;

		public ImageLogic(IImageRepository imageRepo)
		{
			_imageRepo = imageRepo;
		}

		public bool SaveImage(Image image, IFormFile file)
		{
			using (var ms = new MemoryStream())
			{
				file.CopyTo(ms);
				if (ms.Length < 5242880) // 5 * 1024 * 1024 = 5 mb
				{
					image.ImageText = ms.ToArray();
					_imageRepo.Save(image);
					return true;
				}
				else
				{
					return false;
				}
			}

		}
	}
}
