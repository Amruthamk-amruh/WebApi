using System.ComponentModel.DataAnnotations;

namespace DataLibrary.API.Models.DTO
{
	public class LibraryDto
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		//public DateTime TakenDate { get; set; }
		public string Category { get; set; }
		public int Price { get; set; }
	}
}
