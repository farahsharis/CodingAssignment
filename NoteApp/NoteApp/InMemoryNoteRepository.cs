using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{

	public class InMemoryNoteRepository : INoteRepository
	{

		static List<Note> notes = new List<Note>();
		static int currentId = 0;

		public Note Add(Note note)
		{
			if (note == null)
			{
				throw new ArgumentNullException(nameof(note));
			}
			currentId++;
			note.Id = currentId;
			notes.Add(note);
			return note;
		}


		public IList<Note> GetAll(string query = null)
		{
			if (!string.IsNullOrEmpty(query))
			{
				var queryResult = notes.Where(x => x.Body.ToLower().Contains(query.ToLower()));
				return queryResult.ToList();
			}
			return notes;
		}


		public Note GetById(int id)
		{
			var result = notes.FirstOrDefault(x => x.Id == id);
			return result;
		}
	}
}
