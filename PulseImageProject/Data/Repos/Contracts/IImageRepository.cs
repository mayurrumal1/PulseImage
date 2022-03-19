using PulseImageProject.Data.Models;
using System.Collections.Generic;

namespace PulseImageProject.Data.Repos.Contracts
{
	public interface IImageRepository
	{
		/// <summary>
		/// Save the uploaded image to database.
		/// </summary>
		/// <param name="image">The image to save in database.</param>
		public void Save(Image image);

		/// <summary>
		/// Get the images from the database.
		/// </summary>
		/// <param name="imageIds">Array of image ids to get from database.</param>
		/// <returns>The list of Image object.</returns>
		List<Image> GetImages(int[] imageIds = null);
	}
}
