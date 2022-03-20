using Microsoft.AspNetCore.Routing;
using PulseImageProject.Controllers;
using PulseImageProject.Models;
using System.Collections.Generic;
using Xunit;

namespace PulseImageProject.Tests
{
	public class HomeControllerTests
	{
		private readonly HomeController _underTest;

		public HomeControllerTests()
		{
			_underTest = new HomeController(null, null, null);
		}

		/// <summary>
		/// Check that result returns false when view model is empty.
		/// </summary>
		[Fact]
		public void ImageSave_Should_return_false_when_viewmodel_is_empty()
		{
			// Arrange
			ImageViewModel vm = null;

			// Act
			var result = _underTest.Save(vm);
			IDictionary<string, object> data = new RouteValueDictionary(result.Value);

			// Assert
			Assert.False((bool)data["result"]);
			Assert.Matches("The view model is empty.", data["message"].ToString());

		}

		/// <summary>
		/// Check that result returns true when image file is null.
		/// </summary>
		[Fact]
		public void ImageSave_Should_return_false_when_imagefile_is_empty()
		{
			// Arrange
			ImageViewModel vm = new()
			{
				Title = "Test Title"
			};

			// Act
			var result = _underTest.Save(vm);
			IDictionary<string, object> data = new RouteValueDictionary(result.Value);

			// Assert
			Assert.False((bool)data["result"]);
			Assert.Matches("Form was not submitted!", data["message"].ToString());

		}
	}
}
