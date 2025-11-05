using AutoMapper;
using ColegioApp.Data.Interfaces;
using ColegioApp.Entity.DTOs;
using ColegioApp.Entity.Models;

namespace ColegioApp.Business
{
    public class ProfesorService : BaseService<Profesor, ProfesorDto>
    {
        public ProfesorService(IRepository<Profesor> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
