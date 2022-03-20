using Microsoft.AspNetCore.Http;
using Moq;
using PulseImageProject.Data.Models;
using PulseImageProject.Data.Repos.Contracts;
using PulseImageProject.Logic;
using PulseImageProject.Logic.Contracts;
using PulseImageProject.Tests.Helper;
using System;
using Xunit;

namespace PulseImageProject.Tests
{
	public class ImageLogicTests
	{
		private readonly Mock<IImageRepository> _imageRepo;
		private readonly IImageLogic _underTest;

		public ImageLogicTests()
		{
			_imageRepo = new Mock<IImageRepository>();
			_underTest = new ImageLogic(_imageRepo.Object);
		}

		/// <summary>
		/// Verify that the image size is less than 5 MB.
		/// </summary>
		[Fact]
		public void ImageLogic_ImageSmallerThanExpectedSize()
		{
			// Arrange
			var imageFile = TestHelper.GetImageData(@"..\..\..\TestData\Images\Parrots.jpg");
			var image = new Image
			{
				Title = "Parrots",
				ImageName = "Parrots.jpg",
				DateConverted = DateTime.Now
			};

			// Act
			var result = _underTest.SaveImage(image, imageFile);

			// Assert
			Assert.IsType<FormFile>(imageFile);
			Assert.True(result);
		}

		/// <summary>
		/// Check that the image size is not larger than 5 MB.
		/// </summary>
		[Fact]
		public void ImageLogic_ImageBiggerThanExpectedSize()
		{
			// Arrange
			var imageFile = TestHelper.GetImageData(@"..\..\..\TestData\Images\Trees.jpg");
			var image = new Image
			{
				Title = "Trees",
				ImageName = "Trees.jpg",
				DateConverted = DateTime.Now
			};

			// Act
			var result = _underTest.SaveImage(image, imageFile);

			// Assert
			Assert.IsType<FormFile>(imageFile);
			Assert.False(result);
		}
	}
}
