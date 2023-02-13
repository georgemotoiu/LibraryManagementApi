using Library.Application.Contracts.Repositories;
using Library.Application.Models;
using Library.Domain.Entities;
using LibraryManagement.Application.Contracts.Repositories;
using LibraryManagement.Application.Contracts.Services;

namespace LibraryManagement.Infrastructure.Services
{
    public class StudentsService : IStudentsService
    {
        /// <summary>
        ///     The <see cref="IBaseRepository" /> to use.
        /// </summary>        
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        ///     Initializes a new instance of <see cref="ContestsService" />.
        /// </summary>
        /// <param name="contestRepository"></param>
        public StudentsService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;            
        }

        public async Task<Student> AddStudentAsync(StudentDto model)
        {
            return await _studentRepository.AddAsync(model);            
        }

        public async Task<StudentDto> GetStudentAsync(Guid studentId)
        {
            var result = await _studentRepository.GetAsync(c => c.Id == studentId, includeProperties: "Borrows");

            return result.FirstOrDefault();
        }

        public Task<StudentDto> GetStudentIdWithNoTrackingAsync(Guid studentId)
        {
            return _studentRepository.GetByIdWithNoTrackingAsync(studentId);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();            
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsBorrowers()
        {
            return await _studentRepository.GetStudentsThatBorrowedBooksAsync();
        }

        public async Task UpdateStudentAsync(StudentDto student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(StudentDto student)
        {
            await _studentRepository.DeleteAsync(student);
        }

        public async Task<List<StudentDto>> UpdateStudentsByFirstNameAsync()
        {
            return await _studentRepository.UpdateStudentsByFirstNameAsync();
        }
    }
}
