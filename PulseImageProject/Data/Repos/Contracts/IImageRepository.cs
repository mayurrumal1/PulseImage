using PulseImageProject.Data.Models;

namespace PulseImageProject.Data.Repos.Contracts
{
	public interface IImageRepository
	{
		/// <summary>
		/// Save the uploaded image to database.
		/// </summary>
		/// <param name="image">The image to save in database.</param>
		public void Save(Image image);
	}
}
