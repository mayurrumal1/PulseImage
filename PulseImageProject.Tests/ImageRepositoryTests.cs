using Microsoft.EntityFrameworkCore;
using PulseImageProject.Data;
using PulseImageProject.Data.Models;
using PulseImageProject.Data.Repos;
using PulseImageProject.Data.Repos.Contracts;
using PulseImageProject.Tests.Helper;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace PulseImageProject.Tests
{
	public class ImageRepositoryTests
	{
		private readonly IImageRepository _imageRepo;
		private readonly DbContextOptions<DatabaseContext> dbContextOptions;
		private readonly DatabaseContext context;


		public ImageRepositoryTests()
		{
			dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
				.UseInMemoryDatabase(databaseName: "TestDB").Options;
			context = new DatabaseContext(dbContextOptions);
			_imageRepo = new ImageRepository(context);
		}

		/// <summary>
		/// Verify that the image is stored successfully in database.
		/// </summary>
		[Fact]
		public void Save_Image_Record()
		{
			// Arrange
			var ms = new MemoryStream();
			var imageFile = TestHelper.GetImageData(@"..\..\..\TestData\Images\Parrots.jpg");
			imageFile.CopyTo(ms);
			var image = new Image
			{
				Title = "Parrots",
				ImageName = Path.GetFileName(imageFile.FileName),
				ImageText = ms.ToArray(),
				DateConverted = DateTime.Now,
			};

			// Act
			_imageRepo.Save(image);

			// Assert
			Assert.Equal(1, context.Images.Count());
			Assert.Equal(image.ImageName, context.Images.Select(x => x.ImageName).FirstOrDefault().ToString());
			Assert.Equal(image.Title, context.Images.Select(x => x.Title).FirstOrDefault().ToString());
			Assert.Equal(image.ImageText, context.Images.Select(x => x.ImageText).FirstOrDefault().ToArray());

		}
	}
}
