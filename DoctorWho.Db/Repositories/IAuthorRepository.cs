using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> UpdateAuthorAsync(Author auth);
        Task<bool> AuthorExists(int authorId);
    }
}
