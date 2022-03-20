using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PulseImageProject.Data.Repos.Contracts;
using PulseImageProject.Logic.Contracts;
using PulseImageProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PulseImageProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IImageLogic _imageLogic;
		private readonly IImageRepository _imageRepo;

		public HomeController(ILogger<HomeController> logger, IImageLogic imageLogic, IImageRepository imageRepo)
		{
			_logger = logger;
			_imageLogic = imageLogic;
			_imageRepo = imageRepo;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(new ImageViewModel());
		}

		[HttpPost]
		public JsonResult Save(ImageViewModel vm)
		{
			if (vm == null)
			{
				return Json(new { result = false, message = "The view model is empty." });
			}
			if (vm.ImageFile is { } file && file.Length > 0)
			{
				var image = vm.MapToData();
				if (_imageLogic.SaveImage(image, file))
				{
					return Json(new { result = true, message = "Form has been submitted successfully!" });
				}
				else
				{
					return Json(new { result = false, message = "File should be smaller than 5 MB." });
				}
			}

			return Json(new { result = false, message = "Form was not submitted!" });
		}

		[HttpGet]
		public IActionResult Images()
		{
			var images = _imageRepo.GetImages().Select(img => new ImageListViewModel
			{
				Id = img.Id,
				Title = img.Title,
				ImageText = img.ImageText,
				ImageName = img.ImageName,
				DateConverted = img.DateConverted
			});
			return View(images);
		}

		[HttpGet]
		public IActionResult Download(string imageIds)
		{
			var imgArr = Array.ConvertAll(imageIds.Split(',').ToArray(), int.Parse);
			var stream = _imageLogic.GetSelectedImages(imgArr);
			return File(stream, "application/zip", $"Images:{DateTime.Now.ToShortDateString()}.zip");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
