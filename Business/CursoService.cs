using AutoMapper;
using ColegioApp.Data.Interfaces;
using ColegioApp.Entity.DTOs;
using ColegioApp.Entity.Models;

namespace ColegioApp.Business
{
    public class CursoService : BaseService<Curso, CursoDto>
    {
        public CursoService(IRepository<Curso> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
