using AutoMapper;
using ColegioApp.Data.Interfaces;
using ColegioApp.Entity.DTOs;
using ColegioApp.Entity.Models;

namespace ColegioApp.Business
{
    public class EstudianteService : BaseService<Estudiante, EstudianteDto>
    {
        public EstudianteService(IRepository<Estudiante> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
