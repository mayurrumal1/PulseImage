using Microsoft.AspNetCore.Http;
using PulseImageProject.Data.Models;
using PulseImageProject.Data.Repos.Contracts;
using System.IO;
using System.IO.Compression;

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

		public byte[] GetSelectedImages(int[] imageIds)
		{
			var dbImages = _imageRepo.GetImages(imageIds);
			using (var compressedFileStream = new MemoryStream())
			{
				// Refernce: https://docs.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive?view=net-5.0
				// Create a zip archive and store the stream in memory.
				using (var zipArchive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, false))
				{
					foreach (var dbImage in dbImages)
					{
						// Refernce: https://docs.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive.createentry?view=net-5.0
						// Create a zip entry for each image
						var zipEntry = zipArchive.CreateEntry(dbImage.ImageName);

						// Get the stream of the image
						using (var originalFileStream = new MemoryStream(dbImage.ImageText))
						{
							using (var zipEntryStream = zipEntry.Open())
							{
								// Copy the image stream to the zip entry stream
								originalFileStream.CopyTo(zipEntryStream);
							}
						}
					}
				}

				return compressedFileStream.ToArray();
			}
		}

		private void FakeCommit()
		{
			// You are here for fake commit. This will be reverted shortly.
		}

	}
}
