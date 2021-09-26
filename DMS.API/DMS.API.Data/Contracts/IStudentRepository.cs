using DMS.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.API.Data.Contracts
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetStudentById(int id);
    }
}
