using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PulseImageProject.Data.Models
{
	public class Image
	{
		[Key]
		public int Id { get; set; }

		[Column(TypeName = "nvarchar(100)")]
		public string Title { get; set; }

		public byte[] ImageText { get; set; }

		public string ImageName { get; set; }

		[Column(TypeName = "nvarchar(10)")]
		public string ImageType { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime DateConverted { get; set; } = DateTime.Now;
	}
}
