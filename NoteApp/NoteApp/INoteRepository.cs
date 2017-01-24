using System;
using System.Collections.Generic;

namespace NoteApp
{
	public interface INoteRepository
	{
		IList<Note> GetAll(string query = null);
		Note GetById(int id);
		Note Add(Note note);

	}
}
