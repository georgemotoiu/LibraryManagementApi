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

            CreateMap<Author, AuthorDto>()               
                .ForMember(d => d.Id, i => i.MapFrom(s => s.Id))
                .ForMember(d => d.Name, i => i.MapFrom(s => $"{s.FirstName} {s.LastName}"))
                .ForMember(d => d.Books, i => i.MapFrom(s => s.Books));
        }        
    }
}
