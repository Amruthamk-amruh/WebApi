using DataLibrary.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataLibrary.API.Controllers
{
	//[Route("api/[Controller]")]
	[Route("api/Library")]
	[ApiController]
	public class LibraryController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<Library> GetLibraries()
		{
			return new List<Library>()
			{
				new Library { Id = 1, Name = "Wings of Fire" },
				new Library { Id = 2, Name = "Aadujeevitham" }
			};
		}
	}
}  
