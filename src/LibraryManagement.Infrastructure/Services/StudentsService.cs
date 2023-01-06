using Library.Application.Contracts.Repositories;
using Library.Application.Models;
using Library.Domain.Entities;
using LibraryManagement.Application.Contracts.Services;
using MediatR;

namespace LibraryManagement.Infrastructure.Services
{
    public class StudentsService : IStudentsService
    {
        /// <summary>
        ///     The <see cref="IBaseRepository" /> to use.
        /// </summary>
        private readonly IBaseRepository<Student, StudentDto> _studentRepository;

        /// <summary>
        ///     Initializes a new instance of <see cref="ContestsService" />.
        /// </summary>
        /// <param name="contestRepository"></param>
        public StudentsService(IBaseRepository<Student, StudentDto> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> AddStudent(StudentDto model)
        {
            var student = await _studentRepository.AddAsync(model);
            return student;
        }

        public async Task<StudentDto> GetStudent(Guid studentId)
        {
            var result = await _studentRepository.GetAsync(c => c.Id == studentId, includeProperties: "Borrows");

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<StudentDto>> GetStudents()
        {
            var result = await _studentRepository.GetAllAsync();

            return result;
        }
    }
}
