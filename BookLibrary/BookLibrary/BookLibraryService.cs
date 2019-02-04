using System;
using System.Threading.Tasks;
using BookLibrary.Dal;

namespace BookLibrary.Services
{
	public class BookLibraryService : IBookLibraryService
	{
		private readonly IBookLibraryRepository bookLibraryRepository;

		public BookLibraryService()
		{
			this.bookLibraryRepository = new BookLibraryRepository();
		}

		public async Task<int> AddAsync(string name, string content)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException(nameof(name));
			}

			if (content == null)
			{
				throw new ArgumentNullException(nameof(content));
			}

			var book = await this.bookLibraryRepository.AddAsync(name, content);

			return book.Id;
		}
	}
}