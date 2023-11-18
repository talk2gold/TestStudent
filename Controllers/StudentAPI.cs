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

		[HttpPost("id:int", Name = "CreateStudent")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Student> CreateStudent([FromBody] Student student)
		{
			if (student == null)
			{
				return BadRequest();
			}
			if (student.id > 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			if (DataStore.listStudent.FirstOrDefault(s => s.PhoneNr == student.PhoneNr) != null)
			{
				return BadRequest();
			}
			student.id = DataStore.listStudent.OrderByDescending(a => a.id).FirstOrDefault().id + 1;
			DataStore.listStudent.Add(student);
			return CreatedAtRoute("GetStudent", new { id = student.id }, student);
		}



		[HttpPut("id:int", Name ="UpdateStudent")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<Student> UpdateStudent(int id, [FromBody]  Student student)
		{
		 
			if (student == null || student.id != id )
			{
				return BadRequest();
			}
			var student1 = DataStore.listStudent.FirstOrDefault(x => x.id == id);
			if (student1 == null)
			{
				return NoContent();
			}			
			student1.FirstName = student.FirstName;
			student1.LastName = student.LastName;
			student1.PhoneNr = student.PhoneNr;
			student1.BloodGroup = student.BloodGroup;
			return Ok(student1);
		}
	}

}
