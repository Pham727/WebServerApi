using AutoMapper;
using WebServerAPI.Data;
using WebServerAPI.Models;

namespace WebServerAPI.Helpers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
