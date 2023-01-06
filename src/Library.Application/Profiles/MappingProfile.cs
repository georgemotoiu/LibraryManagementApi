using AutoMapper;
using Library.Application.Models;
using Library.Domain.Entities;

namespace Library.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Major, MajorDto>().ReverseMap();
            CreateMap<Borrow, BorrowDto>().ReverseMap();
        }        
    }
}
