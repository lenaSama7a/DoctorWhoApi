using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private DoctorWhoCoreDbContext _context;
        public AuthorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public async Task CreateAuthorAsync(string authorName)
        {
            var author = new Author { AuthorName = authorName };
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(string authorName)
        {
            var author = _context.Authors.Where(a => a.AuthorName == authorName).FirstOrDefault();
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> AuthorExists(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if (author != null)
                return true;
            return false;
        }
    }
}
