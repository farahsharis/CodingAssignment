using System.Collections.Generic;
using System.Linq;
using System.Web.Http;



namespace NoteApp
{
	[Route("api/notes")]
	public class NoteController : ApiController
	{
		INoteRepository repository = new InMemoryNoteRepository();

		public NoteController()
		{

		}

		[HttpGet]
		public IList<Note> Get(string query = "")
		{
			var result = repository.GetAll(query);
			return result.ToList();
		}



		[HttpGet]
		[Route("api/notes/{id}")]
		public Note Get(int id)
		{
			var result = repository.GetById(id);
			if (result == null)
			{
				throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
			}
			return result;
		}



		[HttpPost]
		public Note Post(Note note)
		{

			var result = repository.Add(note);
			return result;

		}
	}
}
