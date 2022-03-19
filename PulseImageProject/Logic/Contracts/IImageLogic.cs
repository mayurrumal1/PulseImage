using Microsoft.AspNetCore.Http;
using PulseImageProject.Data.Models;

namespace PulseImageProject.Logic.Contracts
{
	public interface IImageLogic
	{
		public bool SaveImage(Image img, IFormFile file);
	}
}
