using DataLibrary.API.Models.DTO;

namespace DataLibrary.API.Data
{
	public class LibraryCollection
	{
		public static List<LibraryDto> libraryDetails = new List<LibraryDto>
		{
			new LibraryDto { Id = 1, Name = "Wings of Fire", Category ="Auto Biography", Price = 100 },
			new LibraryDto { Id = 2, Name = "Aadujeevitham" , Category = "Novel", Price = 200}
		};
	}
}
