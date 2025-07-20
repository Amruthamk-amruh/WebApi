using DataLibrary.API.Data;
using DataLibrary.API.Models;	
using DataLibrary.API.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DataLibrary.API.Controllers
{
	//[Route("api/[Controller]")]
	[Route("api/Library")]
	[ApiController]
	public class LibraryController : ControllerBase
	{
		[HttpGet]
		public ActionResult<IEnumerable<LibraryDto>> GetLibraries()
		{
			return Ok(LibraryCollection.libraryDetails);

		}
		[HttpGet("{id:int}", Name = "GetRecord")]

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<LibraryDto> GetLibrary(int id)
		{

			if (id == 0)
			{
				return BadRequest();
			}
			var library = LibraryCollection.libraryDetails.FirstOrDefault(i => i.Id == id);
			if (library == null)
			{
				return NotFound();
			}
			return Ok(library);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<LibraryDto> CreateLibrary([FromBody] LibraryDto library)
		{
			if (library == null)
			{
				return BadRequest(library);
			}
			if (library.Id > 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			library.Id = LibraryCollection.libraryDetails.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
			LibraryCollection.libraryDetails.Add(library);
			return CreatedAtRoute("GetRecord", new { id = library.Id }, library);
		}
		[HttpDelete("{id:int}", Name = "DeleteLibrary")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult DeleteRecord(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}
			var libraryId = LibraryCollection.libraryDetails.FirstOrDefault(i => i.Id == id);
			if (libraryId == null)
			{
				return NotFound();
			}
			LibraryCollection.libraryDetails.Remove(libraryId);
			return NoContent();
		}
		[HttpPut("{id:int}", Name = "UpdateLibrary")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]

		public ActionResult UpdateRecord(int id, [FromBody] LibraryDto libraryDto)
		{
			if (libraryDto == null || id != libraryDto.Id)
			{
				return BadRequest();
			}
			var record = LibraryCollection.libraryDetails.FirstOrDefault(i => i.Id == id);
			record.Name = libraryDto.Name;
			record.Category = libraryDto.Category;
			record.Price = libraryDto.Price;
			return NoContent();
		}
		[HttpPatch("{id:int}", Name = "UpdateLibraryRecord")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]

		public ActionResult UpdatePartialRecord(int id, JsonPatchDocument<LibraryDto> patchDto)
		{
			if (patchDto == null || id == 0)
			{
				return BadRequest();
			}

			var record = LibraryCollection.libraryDetails.FirstOrDefault(i => i.Id == id);
			if (record == null)
			{
				return BadRequest();
			}
			patchDto.ApplyTo(record, ModelState);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return NoContent();

		}

	}
}
