using Microsoft.AspNetCore.Http;
using PulseImageProject.Data.Models;
using System.IO;

namespace PulseImageProject.Models
{
	public class ImageViewModel
	{
		public string Title { get; set; }

		public IFormFile ImageFile { get; set; }

		public Image MapToData() => new()
		{
			Title = Title,
			ImageName = Path.GetFileName(ImageFile.FileName),
			ImageType = Path.GetExtension(ImageFile.FileName)
		};
	}
}
