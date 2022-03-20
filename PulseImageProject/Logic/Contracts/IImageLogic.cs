using Microsoft.AspNetCore.Http;
using PulseImageProject.Data.Models;

namespace PulseImageProject.Logic.Contracts
{
	public interface IImageLogic
	{
		/// <summary>
		/// Check the image size falls in the expected range and save the image in database.
		/// </summary>
		/// <param name="img">Image object</param>
		/// <param name="file">Image file to save</param>
		public bool SaveImage(Image img, IFormFile file);

		/// <summary>
		/// Retrieve the selected images in the form of byte array.
		/// </summary>
		/// <param name="imageIds">Array of image ids</param>
		byte[] GetSelectedImages(int[] imageIds);
	}
}
