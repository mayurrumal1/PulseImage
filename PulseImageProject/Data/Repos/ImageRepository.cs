using PulseImageProject.Data.Models;
using System.Collections.Generic;
using System.Linq;

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

		public List<Image> GetImages(int[] imageIds = null)
		{
			if (imageIds is { } ids)
			{
				return _context.Images.Where(x => ids.Contains(x.Id)).ToList();
			}
			else
			{
				return _context.Images.ToList();
			}
		}
	}
}
