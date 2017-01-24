using System;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace NoteApp.Tests
{
	public class NoteControllerTests
	{


		[Test]
		public void given_there_are_no_notes_when_get_is_called_should_return_an_empty_list()
		{
			var sut = new NoteController();

			var result = sut.Get();

			Assert.IsEmpty(result);
		}


		[Test]
		public void given_there_are_no_notes_and_query_parameter_is_passed_when_get_is_called_should_return_an_empty_list()
		{
			var query = Guid.NewGuid().ToString();
			var sut = new NoteController();

			var result = sut.Get(query);

			Assert.IsEmpty(result);
		}

		[Test]
		public void given_there_are_notes_when_get_is_called_should_return_results()
		{
			var fixture = new Fixture();
			var noteId = fixture.Create<int>();
			var sut = new NoteController();
			var repository = new InMemoryNoteRepository();
			var note = new Note
			{
				Id = noteId,
				Body = "This is a test"
			};
			repository.Add(note);
			var result = sut.Get();

			Assert.IsNotEmpty(result);
		}


		[Test]
		public void given_there_are_notes_when_get_is_called_and_parameter_is_passed_then_should_return_results_if_the_parameter_is_contained_in_the_notes()
		{
			var sut = new NoteController();
			var repository = new InMemoryNoteRepository();
			var note = new Note
			{
				Id = 1,
				Body = "Got Milk?"
			};
			var note2 = new Note
			{
				Id = 2,
				Body = "Hiking Boots"
			};
			repository.Add(note);
			repository.Add(note2);

			var result = sut.Get("milk");

			Assert.IsNotEmpty(result);
			Assert.AreEqual(1, result.Count);
		}
	}
}
