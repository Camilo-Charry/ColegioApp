using AutoMapper;
using ColegioApp.Data.Interfaces;
using ColegioApp.Entity.DTOs;
using ColegioApp.Entity.Models;

namespace ColegioApp.Business
{
    public class MateriaService : BaseService<Materia, MateriaDto>
    {
        public MateriaService(IRepository<Materia> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
