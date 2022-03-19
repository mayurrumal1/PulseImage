using PulseImageProject.Data.Models;

namespace PulseImageProject.Data.Repos
{
	public class ImageRepository : Contracts.IImageRepository
	{
		private readonly DatabaseContext _context;

		public ImageRepository(DatabaseContext context)
		{
			_context = context;
		}

		public void Save(Image image)
		{
			_context.Images.Add(image);
			_context.SaveChanges();
		}
	}
}
