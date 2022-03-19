using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

		public HomeController(ILogger<HomeController> logger, IImageLogic imageLogic)
		{
			_logger = logger;
			_imageLogic = imageLogic;
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
			if (vm.ImageFile != null)
			{
				if (vm.ImageFile.Length > 0)
				{
					var image = vm.MapToData();
					if (_imageLogic.SaveImage(image, vm.ImageFile))
					{
						return Json(new { result = true, message = "Image has been uploaded successfully!" });
					}
					else
					{
						return Json(new { result = false, message = "File should be smaller than 5 mb." });
					}
				}
			}

			return Json(new { result = false, message = "Form was not submitted!" });
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
