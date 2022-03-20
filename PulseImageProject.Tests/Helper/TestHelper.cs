using Microsoft.AspNetCore.Http;
using System.IO;

namespace PulseImageProject.Tests.Helper
{
	public static class TestHelper
	{
		public static IFormFile GetImageData(string path)
		{
			var filepath = Path.GetFullPath(path);
			var stream = File.OpenRead($"{filepath}");
			return new FormFile(stream, 0, stream.Length, null, Path.GetFileName(filepath));
		}
	}
}
