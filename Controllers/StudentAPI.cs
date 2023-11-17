using Microsoft.AspNetCore.Mvc;
using TestStudent.Model;

namespace TestStudent.Controllers
{
	[ApiController]
	public class StudentAPI:ControllerBase
	{
		[Route("api/StudentAPI")]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<Student>> GetStudents()
		{
			List<Student> students = DataStore.listStudent;

			return Ok(students);
		}
		[HttpGet("id:int",Name ="GetStudent")]

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult GetStudent(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}
			Student student = new Student();
			student =DataStore.listStudent.FirstOrDefault(a=> a.id == id);
			if (student == null)
			{
				return NotFound();
			}
			return Ok(student);
		}		
	}

}
